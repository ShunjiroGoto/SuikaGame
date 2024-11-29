using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public GameObject GameManager;//�Q�[���}�l�[�W���[
    public GameObject StartText;//�ŏ��ɉ�ʂɕ\������e�L�X�g

    private float count = 60.0f;//�J�E���g�_�E��

    private float timeLimit = 0.0f;//�^�C�����~�b�g

    public GameObject timeText;//���Ԃ�\������Text�^�̕ϐ�(Inspector�Ńe�L�X�gUI������)


    // Start is called before the first frame update
    void Start()
    {
        GameManager.SetActive(false);//�Q�[���J�n�O�̓Q�[���}�l�[�W���[�͔������Ȃ��悤false�ɂ���
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))//�J�n���ɃQ�[���}�l�[�W���[���I���ɂ��A�\������Ă�������������
        {
            GameManager.SetActive(true);
            StartText.GetComponent<TextMeshProUGUI>().text ="";
        }


        if(GameManager.activeSelf==true)//�Q�[�����Ɏ��Ԃ̕\�����Ǘ�����

        count -= Time.deltaTime;//���Ԃ��J�E���g����֐�
        //Time.deltaTime=�O��̃t���[������̌o�ߎ��ԁBcount�ɒǉ��������邱�ƂŎ��Ԃ�\������

        timeText.GetComponent<TextMeshProUGUI>().text = count.ToString("f1");//���Ԃ�\����������

        if (count <= timeLimit)//�^�C�����~�b�g��0�ɂȂ�ƌ��ʂ�\������V�[���ɐ؂�ւ���
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}
