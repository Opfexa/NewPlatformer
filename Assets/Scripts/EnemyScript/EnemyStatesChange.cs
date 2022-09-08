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
    [SerializeField] int arrowDamage;
    [SerializeField] int magicDamage;
    [SerializeField] int swordDamage;
    [SerializeField] int meleeDamage;
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
        if(enemyBase.isDead)
        {
            enemyBase.enemyAnim.Play("Bandit_Death",-1,0f);
            enemyBase.enemyRb.isKinematic = true;
            enemyBase.GetComponent<BoxCollider2D>().enabled = false;
        }

        targetPos = new Vector2(player.position.x, transform.position.y);
        float distanceFromPlayer = Vector2.Distance(targetPos, transform.position);
        if(distanceFromPlayer < sightArea)
        {
            Chase();
        }
        if(distanceFromPlayer > sightArea && !enemyBase.isDead) Idle();

        if(Vector2.Distance(transform.position, player.position) <= stopChase && canAttack && !enemyBase.isDead) Attack();
        
        if(!lookRight && (player.position.x > transform.position.x) && !enemyBase.isDead)
        Flip();
        if(lookRight && (player.position.x < transform.position.x) && !enemyBase.isDead)
        Flip();
    }
    private void Flip()
    {
        lookRight = !lookRight;
        Vector2 theFace = transform.localScale;
        theFace.x *= -1;
        transform.localScale = theFace;
    }
    private void Chase()
    {
        if(!enemyBase.isDead)
        {
            if (Vector2.Distance(transform.position, player.position) > stopChase)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPos, enemyBase.speed * Time.deltaTime);
                enemyBase.enemyAnim.SetBool("running",true);
                enemyBase.enemyAnim.SetBool("combatIdle",false);
            }
        }

    }
    private void Idle()
    {
        enemyBase.enemyAnim.SetBool("running",false);
        enemyBase.enemyAnim.SetBool("combatIdle",false);
    }
    private void Attack()
    {
        if(!enemyBase.isDead)
        {        
            enemyBase.enemyAnim.SetBool("running",false);
            enemyBase.enemyAnim.SetBool("combatIdle",true);
            enemyBase.enemyAnim.SetTrigger("attack");
            canAttack = false;
            Invoke(nameof(ResetAttack),attackCountDown);
        }
    }
    private void ResetAttack()
    {
        canAttack = true;
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,sightArea);
    }
    private void Damage(int damage)
    {
        if(!enemyBase.isDead)
        {
            enemyBase.health = enemyBase.health - damage;
            enemyBase.enemyAnim.Play("Bandit_Hit",-1,0f);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Arrow")
        {
            Damage(arrowDamage);
        }
        if(other.gameObject.tag == "Magic")
        {
            Damage(magicDamage);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "SwordCollider")
        {
            Damage(swordDamage);
        }
        if(other.gameObject.tag == "MeleeCollider")
        {
            Damage(meleeDamage);
        }
    }
}
