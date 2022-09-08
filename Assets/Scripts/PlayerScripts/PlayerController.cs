using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    internal Rigidbody2D playerRb;
    internal Animator playerAnim;

    [SerializeField]
    internal PlayerMovementScript playerMovementScript;
    [SerializeField]
    internal PlayerAnimationScript playerAnimationScript;
    [SerializeField]
    internal PlayerCollisionScript playerCollisionScript;
    [SerializeField]
    internal PlayerAttackScript playerAttackScript;
    
    internal bool isDead;
    internal bool canHitAnim;
    [SerializeField] internal int damage;
    [SerializeField] internal int health;
    private void Awake() 
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    void Start()
    {
        canHitAnim = true;
    }
    
    void Update()
    {
        if(health <= 0) isDead = true; else isDead = false;

        if(isDead)
        {
            playerRb.isKinematic =true;
            playerRb.GetComponent<BoxCollider2D>().enabled = false;
            playerAnim.SetBool("isDead",true);
        } 
    }
    internal void Damage()
    {
        health = health - damage;
        if(playerAttackScript.onFight && canHitAnim)
        {
            playerAnim.Play("Hurt",-1,0f); 
            canHitAnim = false;
        } 
        else
        {
            if(canHitAnim)
            {
                playerAnim.Play("BigHit",-1,0f);
                canHitAnim = false;
            }
        } 
    }
    
    
    
    
}
