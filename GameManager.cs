using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;//�|�C���g�\���ɕK�v

public class GameManager : MonoBehaviour
{
    
    public GameObject Circle1;//Circle0�`2�擾
    public GameObject Circle2;
    public GameObject Circle0;

    public GameObject Circle1Next;//�Q�[���I�u�W�F�N�g�̕ϐ�Circle0�`2Generator
    public GameObject Circle2Next;
    public GameObject Circle0Next;

    public GameObject Circle1Stay;//�Q�[���I�u�W�F�N�g�̕ϐ�Circle0�`2Stay
    public GameObject Circle2Stay;
    public GameObject Circle0Stay;

    Vector2 mousePos, localPos;//�x�N�g���Ɋւ�����W
    public float MaxPos;//���E�̈ړ������̍ő�l�ƍŏ��l�̕ϐ�
    public float MinPos;
    public GameObject pointText;//�|�C���g�̃e�L�X�g
    
    public static int point;//�|�C���g��

    public float CoolTime=1.0f;//���̃t���[�c�𐶐�����܂ł̃N�[���^�C���̕ϐ�
    public bool ChageFinish = true;//�N�[���^�C�����I������ۂ�true�ɂ���ϐ�

    public AudioClip GetSE;//���̂������̌��ʉ�
    public AudioClip LostSE;//���Ƃ������̌��ʉ�
    AudioSource aud;


    
    void Start()
    {
        Application.targetFrameRate = 60;//�t���[�����[�g��60�ɐݒ�
        Circle2Stay.SetActive(false);//Circle2Stay��Next�����ꂼ���A�N�e�B�u��Ԃɂ���
        Circle2Next.SetActive(false);
        Circle0Stay.SetActive(false);//Circle0Stay��Next�����ꂼ���A�N�e�B�u��Ԃɂ���
        Circle0Next.SetActive(false);

        MaxPos = 1.9f - 0.68f / 2;//�ړ��͈͂�ݒ�
        MinPos = -MaxPos;

        this.aud = GetComponent<AudioSource>();//�I�[�f�B�I�\�[�X���擾
        point = 0;//�|�C���g�\���̂��߂̕ϐ�
        
    }
    
    void Update()
    {
        mousePos = Input.mousePosition;//�J�[�\���̈ʒu���擾


        if (CoolTime >= 1)
        {
            if (Input.GetMouseButton(0))//�{�^���������Ă����
            {
                localPos = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));//�������ʒu���X�N���[�����W�ɕϊ�


                localPos.x = Mathf.Clamp(localPos.x, MinPos, MaxPos);//���E�̈ړ��͈͂̐�����K�p

                transform.localPosition = new Vector2(localPos.x, transform.position.y);//�����Ă����x���W���ړ�

            }
            if (Input.GetMouseButtonUp(0))//�{�^���𗣂������B����int�`�̃��\�b�h�Őݒ肳�ꂽ�l�Ɋ�Â���ʕ\���◎�Ƃ��I�u�W�F�N�g��ݒ�
            {
                if (Circle1Stay.activeSelf == true)
                {
                    Instantiate(Circle1, transform.position, Quaternion.identity);//�A�C�e������
                }
                else if (Circle2Stay.activeSelf == true)
                {
                    Instantiate(Circle2, transform.position, Quaternion.identity);
                }
                else if (Circle0Stay.activeSelf == true)
                {
                    Instantiate(Circle0, transform.position, Quaternion.identity);
                }

                if (Circle1Next.activeSelf == true)//�ҋ@��Ԃ̃t���[�c�ɉ����Ď��ɗ��Ƃ��t���[�c�̕\����ύX����
                {
                    Circle1Stay.SetActive(true);
                    Circle2Stay.SetActive(false);
                    Circle0Stay.SetActive(false);
                }
                else if (Circle2Next.activeSelf == true)
                {
                    Circle1Stay.SetActive(false);
                    Circle2Stay.SetActive(true);
                    Circle0Stay.SetActive(false);
                }
                else if (Circle0Next.activeSelf == true)
                {
                    Circle1Stay.SetActive(false);
                    Circle2Stay.SetActive(false);
                    Circle0Stay.SetActive(true);
                }


                int N = Random.Range(1, 9);//1�`9�܂ł̒l�������_���ň����A���ʂɉ����đҋ@��Ԃ̃t���[�c��ύX����
                if (N > 6) //33%��Circle1�ɐ؂�ւ�
                {
                    Circle1Next.SetActive(true);
                    Circle2Next.SetActive(false);
                    Circle0Next.SetActive(false);
                    MaxPos = 1.9f - 0.68f / 2;
                    MinPos = -MaxPos;
                }
                else if(N>3)//33%��Circle2�ɐ؂�ւ�
                {
                    Circle1Next.SetActive(false);
                    Circle2Next.SetActive(true);
                    Circle0Next.SetActive(false);
                    MaxPos = 1.9f - 0.96f / 2;
                    MinPos = -MaxPos;
                }
                else //33%��Circle0�ɐ؂�ւ�
                {
                    Circle1Next.SetActive(false);
                    Circle2Next.SetActive(false);
                    Circle0Next.SetActive(true);
                    MaxPos = 1.9f - 0.48f / 2;
                    MinPos = -MaxPos;
                }


                CoolTime = 0;//CoolTime��0,ChargeFinish��false�ɂ��āA�t���[�c�𐶐�����|�C���g���㕔�Ɉړ�����
                ChageFinish = false;
                transform.localPosition = new Vector2(0, 3.0f);

            }
        }

        if (CoolTime < 1.0)//�N�[���^�C����1�����̎��Ƀt���[�c�𐶐�����
        {
            CoolTime += Time.deltaTime*2;//���Ԃ��J�E���g����֐�
                                         //Time.deltaTime=�O��̃t���[������̌o�ߎ��ԁBcount�ɒǉ��������邱�ƂŎ��Ԃ�\������
            if (Circle1Stay.activeSelf == true)//�o�ߎ��Ԃɉ����ăt���[�c�̕\����ύX����
            {
                if (CoolTime < 1/4f)
                {
                    Circle1Stay.GetComponent<Image>().fillAmount = 0/3f;
                }
                else if (CoolTime < 2/4f)
                {
                    Circle1Stay.GetComponent<Image>().fillAmount = 1/3f;
                }
                else if (CoolTime < 3/4f)
                {
                    Circle1Stay.GetComponent<Image>().fillAmount = 2/3f;
                }
                else
                {
                    Circle1Stay.GetComponent<Image>().fillAmount = 3/3f;
                }

            }
            else if (Circle2Stay.activeSelf == true)//���̃t���[�c�ł����l�ɍs��
            {
                if (CoolTime < 1 / 4f)
                {
                    Circle2Stay.GetComponent<Image>().fillAmount = 0/3f;
                }
                else if (CoolTime < 2 / 4f)
                {
                    Circle2Stay.GetComponent<Image>().fillAmount = 1/3f;
                }
                else if (CoolTime < 3 / 4f)
                {
                    Circle2Stay.GetComponent<Image>().fillAmount = 2/3f;
                }
                else
                {
                    Circle2Stay.GetComponent<Image>().fillAmount = 3/3f;
                }
            }
            else if (Circle0Stay.activeSelf == true)
            {
                if (CoolTime < 1 / 4f)
                {
                    Circle0Stay.GetComponent<Image>().fillAmount = 0 / 3f;
                }
                else if (CoolTime < 2 / 4f)
                {
                    Circle0Stay.GetComponent<Image>().fillAmount = 1 / 3f;
                }
                else if (CoolTime < 3 / 4f)
                {
                    Circle0Stay.GetComponent<Image>().fillAmount = 2 / 3f;
                }
                else
                {
                    Circle0Stay.GetComponent<Image>().fillAmount = 3 / 3f;
                }
            }
        }
        else if(ChageFinish==false)//�N�[���^�C����1�ȏ�ɂȂ�Έʒu�����ɖ߂��āAChargeFinish��true�ɂ���
        {
            transform.localPosition = new Vector2(localPos.x, 2.5f);
            ChageFinish = true;
        }

        
        


    }

    public void GetPoint(int a)//�I�u�W�F�N�g���m�����̂��ĂP�����N��̃I�u�W�F�N�g�ɂȂ����Ƃ��ɌĂяo����郁�\�b�h
    {
        point += 1 * a;//�|�C���g�ǉ�
        pointText.GetComponent<TextMeshProUGUI>().text =
            point+"point";//�|�C���g�\��
        this.aud.PlayOneShot(this.GetSE);//���ʉ����Đ�
    }

    public void LostPoint(int b)
    {
        point -= 1 * b;//�|�C���g����
        pointText.GetComponent<TextMeshProUGUI>().text =
            point + "point";//�|�C���g�\��
        this.aud.PlayOneShot(this.LostSE);//���ʉ����Đ�
    }
}
