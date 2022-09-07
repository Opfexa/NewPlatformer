using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;
    [Header("Movement Variable")]
    internal float horizontal;
    internal float maxSpeed;
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    internal bool faceRight;
    internal bool onGround;
    internal bool canDrawSword;
    // Start is called before the first frame update
    void Start()
    {
        faceRight = true;
        canDrawSword = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Movement();
        Jump();
    }
    public virtual void Movement()
    {
        playerController.playerRb.velocity = new Vector2(horizontal * speed,playerController.playerRb.velocity.y);
        if (horizontal > 0 && !faceRight)
            Flip();
        else if (horizontal < 0 && faceRight)
            Flip();
    }
    private void Flip()
    {
        faceRight = !faceRight;
        Vector2 theFace = transform.localEulerAngles;
        if(faceRight)
        theFace.y = 0;
        if(!faceRight)
        theFace.y = 180;
        transform.localEulerAngles = theFace;

    }
    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && onGround)
        {
            onGround = false;
            playerController.playerAnim.SetBool("jump",true);
            playerController.playerRb.velocity = new Vector2(playerController.playerRb.velocity.x, jumpSpeed);
        }
    }
}
