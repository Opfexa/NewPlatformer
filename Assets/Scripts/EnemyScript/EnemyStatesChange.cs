using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatesChange : MonoBehaviour
{
    public EnemyBase enemyBase;
    private Transform player;
    public float stopChase;
    private bool lookRight;
    private Vector2 targetPos;
    private bool canAttack;
    [SerializeField] int attackCountDown;
    public float sightArea;
    private void Awake() 
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lookRight = false;
        canAttack = true;
    }
    private void Update() 
    {
        targetPos = new Vector2(player.position.x, transform.position.y);
        float distanceFromPlayer = Vector2.Distance(targetPos, transform.position);
        if(distanceFromPlayer < sightArea)
        {
            Chase();
        }
        if(distanceFromPlayer > sightArea) Idle();

        if(Vector2.Distance(transform.position, player.position) <= stopChase && canAttack) Attack();
        
        if(!lookRight && (player.position.x > transform.position.x))
        Flip();
        if(lookRight && (player.position.x < transform.position.x))
        Flip();
    }
    private void Flip()
    {
        lookRight = !lookRight;
        Vector2 theFace = transform.localEulerAngles;
        if(lookRight)
        theFace.y = 0;
        if(!lookRight)
        theFace.y = 180;
        transform.localEulerAngles = theFace;
    }
    private void Chase()
    {
        if (Vector2.Distance(transform.position, player.position) > stopChase)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, enemyBase.speed * Time.deltaTime);
            enemyBase.enemyAnim.SetBool("running",true);
            enemyBase.enemyAnim.SetBool("combatIdle",false);
        }
        
    }
    private void Idle()
    {
        enemyBase.enemyAnim.SetBool("running",false);
        enemyBase.enemyAnim.SetBool("combatIdle",false);
    }
    private void Attack()
    {
        enemyBase.enemyAnim.SetBool("running",false);
        enemyBase.enemyAnim.SetBool("combatIdle",true);
        enemyBase.enemyAnim.SetTrigger("attack");
        canAttack = false;
        Invoke(nameof(ResetAttack),attackCountDown);
    }
    private void ResetAttack()
    {
        canAttack = true;
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,sightArea);
    }
}
