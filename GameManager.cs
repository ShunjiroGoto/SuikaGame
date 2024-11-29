using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;//ポイント表示に必要

public class GameManager : MonoBehaviour
{
    
    public GameObject Circle1;//Circle0～2取得
    public GameObject Circle2;
    public GameObject Circle0;

    public GameObject Circle1Next;//ゲームオブジェクトの変数Circle0～2Generator
    public GameObject Circle2Next;
    public GameObject Circle0Next;

    public GameObject Circle1Stay;//ゲームオブジェクトの変数Circle0～2Stay
    public GameObject Circle2Stay;
    public GameObject Circle0Stay;

    Vector2 mousePos, localPos;//ベクトルに関する座標
    public float MaxPos;//左右の移動距離の最大値と最小値の変数
    public float MinPos;
    public GameObject pointText;//ポイントのテキスト
    
    public static int point;//ポイント数

    public float CoolTime=1.0f;//次のフルーツを生成するまでのクールタイムの変数
    public bool ChageFinish = true;//クールタイムが終わった際にtrueにする変数

    public AudioClip GetSE;//合体した時の効果音
    public AudioClip LostSE;//落とした時の効果音
    AudioSource aud;


    
    void Start()
    {
        Application.targetFrameRate = 60;//フレームレートを60に設定
        Circle2Stay.SetActive(false);//Circle2StayとNextをそれぞれ非アクティブ状態にする
        Circle2Next.SetActive(false);
        Circle0Stay.SetActive(false);//Circle0StayとNextをそれぞれ非アクティブ状態にする
        Circle0Next.SetActive(false);

        MaxPos = 1.9f - 0.68f / 2;//移動範囲を設定
        MinPos = -MaxPos;

        this.aud = GetComponent<AudioSource>();//オーディオソースを取得
        point = 0;//ポイント表示のための変数
        
    }
    
    void Update()
    {
        mousePos = Input.mousePosition;//カーソルの位置を取得


        if (CoolTime >= 1)
        {
            if (Input.GetMouseButton(0))//ボタンを押している間
            {
                localPos = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));//押した位置をスクリーン座標に変換


                localPos.x = Mathf.Clamp(localPos.x, MinPos, MaxPos);//左右の移動範囲の制限を適用

                transform.localPosition = new Vector2(localPos.x, transform.position.y);//押している間x座標を移動

            }
            if (Input.GetMouseButtonUp(0))//ボタンを離した時。下のint～のメソッドで設定された値に基づき画面表示や落とすオブジェクトを設定
            {
                if (Circle1Stay.activeSelf == true)
                {
                    Instantiate(Circle1, transform.position, Quaternion.identity);//アイテム投下
                }
                else if (Circle2Stay.activeSelf == true)
                {
                    Instantiate(Circle2, transform.position, Quaternion.identity);
                }
                else if (Circle0Stay.activeSelf == true)
                {
                    Instantiate(Circle0, transform.position, Quaternion.identity);
                }

                if (Circle1Next.activeSelf == true)//待機状態のフルーツに応じて次に落とすフルーツの表示を変更する
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


                int N = Random.Range(1, 9);//1～9までの値をランダムで引き、結果に応じて待機状態のフルーツを変更する
                if (N > 6) //33%でCircle1に切り替え
                {
                    Circle1Next.SetActive(true);
                    Circle2Next.SetActive(false);
                    Circle0Next.SetActive(false);
                    MaxPos = 1.9f - 0.68f / 2;
                    MinPos = -MaxPos;
                }
                else if(N>3)//33%でCircle2に切り替え
                {
                    Circle1Next.SetActive(false);
                    Circle2Next.SetActive(true);
                    Circle0Next.SetActive(false);
                    MaxPos = 1.9f - 0.96f / 2;
                    MinPos = -MaxPos;
                }
                else //33%でCircle0に切り替え
                {
                    Circle1Next.SetActive(false);
                    Circle2Next.SetActive(false);
                    Circle0Next.SetActive(true);
                    MaxPos = 1.9f - 0.48f / 2;
                    MinPos = -MaxPos;
                }


                CoolTime = 0;//CoolTimeを0,ChargeFinishをfalseにして、フルーツを生成するポイントを上部に移動する
                ChageFinish = false;
                transform.localPosition = new Vector2(0, 3.0f);

            }
        }

        if (CoolTime < 1.0)//クールタイムが1未満の時にフルーツを生成する
        {
            CoolTime += Time.deltaTime*2;//時間をカウントする関数
                                         //Time.deltaTime=前回のフレームからの経過時間。countに追加し続けることで時間を表示する
            if (Circle1Stay.activeSelf == true)//経過時間に応じてフルーツの表示を変更する
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
            else if (Circle2Stay.activeSelf == true)//他のフルーツでも同様に行う
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
        else if(ChageFinish==false)//クールタイムが1以上になれば位置を下に戻して、ChargeFinishをtrueにする
        {
            transform.localPosition = new Vector2(localPos.x, 2.5f);
            ChageFinish = true;
        }

        
        


    }

    public void GetPoint(int a)//オブジェクト同士が合体して１ランク上のオブジェクトになったときに呼び出されるメソッド
    {
        point += 1 * a;//ポイント追加
        pointText.GetComponent<TextMeshProUGUI>().text =
            point+"point";//ポイント表示
        this.aud.PlayOneShot(this.GetSE);//効果音を再生
    }

    public void LostPoint(int b)
    {
        point -= 1 * b;//ポイント減少
        pointText.GetComponent<TextMeshProUGUI>().text =
            point + "point";//ポイント表示
        this.aud.PlayOneShot(this.LostSE);//効果音を再生
    }
}
