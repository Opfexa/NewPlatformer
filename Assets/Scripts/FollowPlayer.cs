using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offsett;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate() 
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y,player.transform.position.z) + offsett;
    }
}
