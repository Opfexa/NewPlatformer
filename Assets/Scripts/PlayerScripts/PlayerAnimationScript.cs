using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementAnimations();
        if(playerController.playerAnim.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            playerController.canHitAnim = true;
        }
    }
    private void MovementAnimations()
    {
        if(playerController.playerAnim.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            playerController.playerMovementScript.canDrawSword = true;
        }
        else
        playerController.playerMovementScript.canDrawSword = false;

        playerController.playerAnim.SetFloat("speed",Mathf.Abs(playerController.playerMovementScript.horizontal));
        playerController.playerAnim.SetFloat("yVelocity",playerController.playerRb.velocity.y);
    }
}
