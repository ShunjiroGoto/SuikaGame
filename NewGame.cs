using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class NewGame : MonoBehaviour
{

    public GameObject resultText;//���ʂ̃e�L�X�g

    void Start()
    {
        resultText.GetComponent<TextMeshProUGUI>().text =
            GameManager.point.ToString() + "Point";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGameButtonDown()
    {
        SceneManager.LoadScene("GameScene");
    }
}
