using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;
    [Header("Fight Mode")]
    internal bool onFight;
    internal bool attacking;
    internal int sCombo;
    internal int pCombo;
    internal int kCombo;
    [SerializeField] GameObject arrow;
    [SerializeField] Transform arrowStartPos;
    [SerializeField] GameObject spell;
    [SerializeField] Transform spellStartPos;
    // Start is called before the first frame update
    void Start()
    {
        onFight = false;
        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        Fight();
        Inputs();
        
    }
    public virtual void Fight()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && playerController.playerMovementScript.onGround && playerController.playerMovementScript.canDrawSword)
        {
            onFight = !onFight;
            playerController.playerMovementScript.canDrawSword = false;
        }

        if(onFight == true)
        {
            playerController.playerAnim.SetBool("onFight",true);
        }
        
        else if(onFight == false)
        playerController.playerAnim.SetBool("onFight",false);

        
    }
    void Inputs()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            playerController.playerAnim.SetTrigger("sAttack");
            sCombo++;
            playerController.playerAnim.SetBool("sCombo",true);
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            playerController.playerAnim.SetTrigger("pAttack");
            pCombo++;
            playerController.playerAnim.SetBool("pCombo",true);
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            playerController.playerAnim.SetTrigger("bAttack");
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            playerController.playerAnim.SetTrigger("mAttack");
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            playerController.playerAnim.SetTrigger("kAttack");
            kCombo++;
            playerController.playerAnim.SetBool("kCombo",true);
        }
    }
    public void Spell()
    {
        Instantiate(spell,new Vector2(spellStartPos.transform.position.x, spellStartPos.transform.position.y),transform.rotation);
    }
    public void Bow()
    {
        Instantiate(arrow,arrowStartPos.position,transform.rotation);
    }
    
}
