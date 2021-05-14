using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

        //ボールが見える可能性のあるz軸の最大値
        private float visiblePosZ = -6.5f;
        private int Point = 0;
        
        //ゲームオーバを表示するテキスト
        private GameObject gameoverText;
        private GameObject PointText;
        // Use this for initialization
        void Start ()
        {
                //シーン中のGameOverTextオブジェクトを取得
                this.gameoverText = GameObject.Find("GameOverText");
                     PointText = GameObject.Find("PointText");
        }

    
        // Update is called once per frame
        void Update()
        {
            //ボールが画面外に出た場合
            if (this.transform.position.z < this.visiblePosZ)
            {
                //GameoverTextにゲームオーバを表示
                this.gameoverText.GetComponent<Text>().text = "GameOver";
            }
            PointText.GetComponent<Text>().text = Point + "Point";
            Debug.Log(Point);
        }
        void OnCollisionEnter(Collision other)
        {
           if (other.gameObject.tag == "SmallStarTag")
            {
            this.Point += 1;
             }
            else if (other.gameObject.tag == "LargeStarTag")
             {
            this.Point += 5;
             }
             else if (other.gameObject.tag == "SmallCloudTag")
             {
            this.Point += 3;
              }
             else if (other.gameObject.tag == "LargeCloudTag")
              {
            this.Point += 10;
              }
        }
}