using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadLineController : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerStay2D(Collider2D other)
    {
        rb = other.gameObject.GetComponent<Rigidbody2D>();
        if(rb.velocity.y>=0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
