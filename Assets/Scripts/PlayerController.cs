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
    
    private void Awake() 
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    
    
    
    
    
}
