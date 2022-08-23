using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator playerAnim;

    [Header("Movement Variable")]
    private float horizontal;
    private float maxSpeed;
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    private bool faceRight;
    public bool onGround;
    public bool canDrawSword;
    [Header("Fight Mode")]
    public bool onFight;
    private bool attacking;
    public int sCombo;
    public int pCombo;
    public int kCombo;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        faceRight = true;
        onFight = false;
        attacking = false;
        canDrawSword = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        MovementAnimations();
        Fight();
        Jump();
    }
    private void FixedUpdate() 
    {
        Movement();
    }
    public virtual void Movement()
    {
        playerRb.velocity = new Vector2(horizontal * speed,playerRb.velocity.y);
        if (horizontal > 0 && !faceRight)
            Flip();
        else if (horizontal < 0 && faceRight)
            Flip();
    }
    private void MovementAnimations()
    {
        if(playerAnim.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            canDrawSword = true;
            playerAnim.ResetTrigger("bAttack");
            playerAnim.ResetTrigger("sAttack");
            playerAnim.ResetTrigger("pAttack");
            playerAnim.ResetTrigger("mAttack");
            playerAnim.ResetTrigger("kAttack");
        }
        else
        canDrawSword = false;
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
        if(Input.GetKeyDown(KeyCode.LeftShift) && onGround && canDrawSword)
        {
            onFight = !onFight;
            canDrawSword = false;
        }

        if(onFight == true)
        {
            playerAnim.SetBool("onFight",true);
        }
        
        else if(onFight == false)
        playerAnim.SetBool("onFight",false);

        if(Input.GetKeyDown(KeyCode.H))
        {
            playerAnim.SetTrigger("sAttack");
            sCombo++;
            playerAnim.SetBool("sCombo",true);
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            playerAnim.SetTrigger("pAttack");
            pCombo++;
            playerAnim.SetBool("pCombo",true);
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            playerAnim.SetTrigger("bAttack");
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            playerAnim.SetTrigger("mAttack");
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            playerAnim.SetTrigger("kAttack");
            kCombo++;
            playerAnim.SetBool("kCombo",true);
        }
    }
    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && onGround)
        {
            onGround = false;
            playerAnim.SetBool("jump",true);
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpSpeed);

        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.tag == "Ground")
        {
            onGround = true;
            playerAnim.SetBool("jump",false);
        }    
    }
}
