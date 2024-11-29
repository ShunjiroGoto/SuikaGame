using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleController : MonoBehaviour
{
    //public GameObject Circle0;
    public GameObject Circle1;//����Circle���i�[����GameObject�^�ϐ�
    public GameObject Circle2;
    public GameObject Circle3;
    public GameObject Circle4;
    public GameObject Circle5;
    public GameObject Circle6;
    public GameObject Circle7;
    GameObject director;//GameDirector�������邽�߂̕ϐ�

    // Start is called before the first frame update
    void Start()
    {
        this.director = GameObject.Find("GameManager");//GameManager�ƕR�Â���


    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<-6.0f)//���̍��W�ȏ�Ɉړ������炱�̃Q�[���I�u�W�F�N�g����������
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)//�����t���[�c�ɓ��������ۂ̏���
    {
        if(other.gameObject.tag==this.gameObject.tag)//���̃Q�[���I�u�W�F�N�g(this)�Ƒ��̃Q�[���I�u�W�F�N�g(other)�̃^�O��������������
        {
            if (this.transform.position.y > other.transform.position.y | this.transform.position.y == other.transform.position.y & this.transform.position.x > other.transform.position.x)
            {
                //�uthis��y���W�̒l��other���傫���v�������́uthis��othet��y���W�̒l����������x���W�̒l��this���other�̕����傫���Ƃ��v

                Vector2 pos = Vector2.Lerp(this.transform.position, other.transform.position, 0.5f);//�Q�̃I�u�W�F�N�g�̒��_(�n�_,�I�_,float�^�ŗ��[�̋������P�Ƃ������̊���)

               
                if (this.gameObject.tag == "Circle0")//�t���[�c�̎�ނɉ����Ă��̏�Ŏ��̃t���[�c�𐶐����ă|�C���g���l������
                {
                    Instantiate(Circle1, pos, Quaternion.identity);
                    //GameManager.point += 1;//�����C�N�O�̃X�N���v�g
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

                Destroy(other.gameObject);//���̑O�̃t���[�c����������
                Destroy(this.gameObject);


            }
        }
    }
}
