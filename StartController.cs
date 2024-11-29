using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public GameObject GameManager;//ゲームマネージャー
    public GameObject StartText;//最初に画面に表示するテキスト

    private float count = 60.0f;//カウントダウン

    private float timeLimit = 0.0f;//タイムリミット

    public GameObject timeText;//時間を表示するText型の変数(InspectorでテキストUIを入れる)


    // Start is called before the first frame update
    void Start()
    {
        GameManager.SetActive(false);//ゲーム開始前はゲームマネージャーは反応しないようfalseにする
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))//開始時にゲームマネージャーをオンにし、表示されていた文字を消す
        {
            GameManager.SetActive(true);
            StartText.GetComponent<TextMeshProUGUI>().text ="";
        }


        if(GameManager.activeSelf==true)//ゲーム中に時間の表示を管理する

        count -= Time.deltaTime;//時間をカウントする関数
        //Time.deltaTime=前回のフレームからの経過時間。countに追加し続けることで時間を表示する

        timeText.GetComponent<TextMeshProUGUI>().text = count.ToString("f1");//時間を表示し続ける

        if (count <= timeLimit)//タイムリミットが0になると結果を表示するシーンに切り替える
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}
