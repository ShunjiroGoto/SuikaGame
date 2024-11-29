using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultController : MonoBehaviour
{
    public GameObject resultText;//結果のテキスト

    // Start is called before the first frame update
    void Start()
    {
        resultText.GetComponent<TextMeshProUGUI>().text =
            GameManager.point.ToString() + "Point";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetryButtonDown()
    {
        Debug.Log("あ");
        SceneManager.LoadScene("GameScene");
    }
}
