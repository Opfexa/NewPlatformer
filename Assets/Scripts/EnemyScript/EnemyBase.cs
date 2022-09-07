using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    internal Rigidbody2D enemyRb;
    internal Animator enemyAnim;
    [SerializeField] internal float speed;
    [SerializeField] internal int health;
    public EnemyStatesChange enemyStatesChange;
    private void Awake() 
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
