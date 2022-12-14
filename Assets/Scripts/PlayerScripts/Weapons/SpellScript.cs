using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{
    [SerializeField] float spellSpeed;
    Renderer m_Renderer;
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!m_Renderer.isVisible)
        Destroy(gameObject);
        else
        transform.Translate(new Vector2(1,0) *spellSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
    
}
