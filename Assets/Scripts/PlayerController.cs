using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator playerAnim;

    //Movement
    private float horizontal;
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    private bool faceRight;

    //Fight Mode
    public bool onFight;
    private bool attacking;
    public int sCombo;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        faceRight = true;
        onFight = false;
        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Movement();
        MovementAnimations();
        Fight();
        Jump();
    }
    public virtual void Movement()
    {
        playerRb.velocity = new Vector2(horizontal * speed,playerRb.velocity.y) ;
        if (horizontal > 0 && !faceRight)
            Flip();
        else if (horizontal < 0 && faceRight)
            Flip();
    }
    private void MovementAnimations()
    {
        playerAnim.SetFloat("speed",Mathf.Abs(horizontal));
        playerAnim.SetFloat("yVelocity",playerRb.velocity.y);
    }
    private void Flip()
    {
        faceRight = !faceRight;
        Vector2 theFace = transform.localScale;
        theFace.x *= -1;
        transform.localScale = theFace;

    }
    public virtual void Fight()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        onFight = !onFight;

        if(onFight == true)
        playerAnim.SetBool("onFight",true);
        else if(onFight == false)
        playerAnim.SetBool("onFight",false);

        if(Input.GetKeyDown(KeyCode.K))
        {
            playerAnim.SetTrigger("sAttack");
            sCombo++;
            playerAnim.SetBool("sCombo",true);
        }
        
    }
    private void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            playerAnim.SetBool("jump",true);
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpSpeed);
        }
    }
}
