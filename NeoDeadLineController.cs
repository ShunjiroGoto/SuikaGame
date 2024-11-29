using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeoDeadLineController : MonoBehaviour
{

    Rigidbody2D rb;
    public GameObject director;
    // Start is called before the first frame update
    void Start()
    {
        //this.director = GameObject.Find("GameManager");//GameManager‚Æ•R‚Ã‚¯‚é
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D other)
    {
        rb = other.gameObject.GetComponent<Rigidbody2D>();
        //if (rb.velocity.y >= 0)
        //{
            if (other.gameObject.tag == "Circle0")
            {
                director.GetComponent<GameManager>().LostPoint(18);
            }
            else if (other.gameObject.tag == "Circle1")
            {
                director.GetComponent<GameManager>().LostPoint(12);
            }
            else if (other.gameObject.tag == "Circle2")
            {
                director.GetComponent<GameManager>().LostPoint(8);
            }
            else if (other.gameObject.tag == "Circle3")
            {
                director.GetComponent<GameManager>().LostPoint(4);
            }
            else if (other.gameObject.tag == "Circle4")
            {
                director.GetComponent<GameManager>().LostPoint(2);
            }
            else if (other.gameObject.tag == "Circle5")
            {
                director.GetComponent<GameManager>().LostPoint(1);
            }
            else if (other.gameObject.tag == "Circle6")
            {
                director.GetComponent<GameManager>().LostPoint(0);
            }
            else if (other.gameObject.tag == "Circle7")
            {
                director.GetComponent<GameManager>().LostPoint(1);
                //SceneManager.LoadScene("GameClear");
            }
            Destroy(other.gameObject);
        //}
    }
}
