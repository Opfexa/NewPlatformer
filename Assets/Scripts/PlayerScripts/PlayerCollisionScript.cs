using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.tag == "Ground")
        {
            playerController.playerMovementScript.onGround = true;
            playerController.playerAnim.SetBool("jump",false);
        }    
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "EnemySword")
        {
            playerController.Damage();
        }
    }
}
