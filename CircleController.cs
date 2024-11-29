using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleController : MonoBehaviour
{
    //public GameObject Circle0;
    public GameObject Circle1;//他のCircleを格納するGameObject型変数
    public GameObject Circle2;
    public GameObject Circle3;
    public GameObject Circle4;
    public GameObject Circle5;
    public GameObject Circle6;
    public GameObject Circle7;
    GameObject director;//GameDirectorを見つけるための変数

    // Start is called before the first frame update
    void Start()
    {
        this.director = GameObject.Find("GameManager");//GameManagerと紐づける


    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<-6.0f)//一定の座標以上に移動したらこのゲームオブジェクトを消去する
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)//同じフルーツに当たった際の処理
    {
        if(other.gameObject.tag==this.gameObject.tag)//このゲームオブジェクト(this)と他のゲームオブジェクト(other)のタグが同じだった時
        {
            if (this.transform.position.y > other.transform.position.y | this.transform.position.y == other.transform.position.y & this.transform.position.x > other.transform.position.x)
            {
                //「thisのy座標の値がotherより大きい」もしくは「thisとothetのy座標の値が同じかつx座標の値がthisよりotherの方が大きいとき」

                Vector2 pos = Vector2.Lerp(this.transform.position, other.transform.position, 0.5f);//２つのオブジェクトの中点(始点,終点,float型で両端の距離を１とした時の割合)

               
                if (this.gameObject.tag == "Circle0")//フルーツの種類に応じてその場で次のフルーツを生成してポイントを獲得する
                {
                    Instantiate(Circle1, pos, Quaternion.identity);
                    //GameManager.point += 1;//リメイク前のスクリプト
                    this.director.GetComponent<GameManager>().GetPoint(1);
                }
                else if (this.gameObject.tag == "Circle1")
                {
                    Instantiate(Circle2, pos, Quaternion.identity);
                    //GameManager.point += 2;
                    this.director.GetComponent<GameManager>().GetPoint(2);
                }
                else if (this.gameObject.tag == "Circle2")
                {
                    Instantiate(Circle3, pos, Quaternion.identity);
                    //GameManager.point += 4;
                    this.director.GetComponent<GameManager>().GetPoint(4);
                }
                else if (this.gameObject.tag == "Circle3")
                {
                    Instantiate(Circle4, pos, Quaternion.identity);
                    //GameManager.point += 8;
                    this.director.GetComponent<GameManager>().GetPoint(8);
                }
                else if (this.gameObject.tag == "Circle4")
                {
                    Instantiate(Circle5, pos, Quaternion.identity);
                    //GameManager.point += 16;
                    this.director.GetComponent<GameManager>().GetPoint(16);
                }
                else if (this.gameObject.tag == "Circle5")
                {
                    Instantiate(Circle6, pos, Quaternion.identity);
                    //GameManager.point += 32;
                    this.director.GetComponent<GameManager>().GetPoint(32);
                }
                else if (this.gameObject.tag == "Circle6")
                {
                    //Instantiate(Circle7, pos, Quaternion.identity);
                    //GameManager.point += 64;
                    this.director.GetComponent<GameManager>().GetPoint(64);
                }
                else if (this.gameObject.tag == "Circle7")
                {
                    this.director.GetComponent<GameManager>().GetPoint(128);
                    //SceneManager.LoadScene("GameClear");
                }

                Destroy(other.gameObject);//合体前のフルーツを消去する
                Destroy(this.gameObject);


            }
        }
    }
}
