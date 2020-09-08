using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    //移動量
    private float Move_Ramge = 0.1f;
    //方向
    private int Move_direction;
    //アニメーター
    [SerializeField]
    private Animator animator;
    //アニメーター用移動方向確認
    private float Animation_Move;
    Vector2 Pos;
    Vector2 scale;

    void Start()
    {
        Animation_Move = 0;
        Menu_Open = false;
        Item = new bool[6] { false, false, false, false, false, false };
        Have_Item = 0;
    }

    void Update()
    {
        Transform transform = this.transform;
        Controller();
        animator.SetFloat("Move", Move_direction);
        //テスト
        Gimmick();
        Item_Inventory();
    }
    #region 移動処理
    //キー操作
    private void Controller()
    {
        if (Menu_Open == false)
        {
            Pos = transform.position;
            scale = transform.localScale;
            //右
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                //向き指定
                Move_direction = 1;
                //移動
                Move_Controller();
            }
            //左
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                //向き指定
                Move_direction = -1;
                //移動
                Move_Controller();
            }
            //停止
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Move_direction = 0;
            }
        }
    }
    private void Move_Controller()
    {
        //移動
        Pos.x += Move_Ramge * Move_direction;
        //アニメーション
        Animation_Move = Move_direction;
        //向き
        scale.x = Move_direction;
        transform.position = Pos;
        transform.localScale = scale;
    }
    #endregion

    #region アイテム取得処理
    private bool Flag = false;
    private GameObject Object;

    /// <summary>
    /// 0,Lader
    /// 1,Candle
    /// 2,Match
    /// 3,Key_Passage
    /// 4,Key_Elevator
    /// 5,Key_Unown
    /// </summary>
    private bool[] Item;

    private int Have_Item;

    private Sprite sprite;

    //アイテムに触れたとき
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ///if(アイテムかどうかの判別)
        Flag = true;
        Object = collision.gameObject;
        Debug.Log("何かあるかも？");
    }


    private void Gimmick()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Flag == true)
            {
                Destroy(Object);
                //何かしらの処理
                switch (Object.name)
                {
                    case "Lader":
                        Item[0] = true;
                        sprite = Resources.Load<Sprite>("Lader");
                        Menu.GetComponent<MenuController>().button[Have_Item].transform.GetChild(1).GetComponent<Image>().sprite = sprite;
                        Debug.Log("梯子を見つけた");
                        break;
                    case "Candle":
                        Item[1] = true;
                        Debug.Log("ろうそくを見つけた");
                        break;
                    case "Match":
                        Item[2] = true;
                        Debug.Log("マッチを見つけた");
                        break;
                    case "Key_Passage":
                        Item[3] = true;
                        Debug.Log("どこかのカギを見つけた");
                        break;
                    case "Key_Elevator":
                        Item[4] = true;
                        Debug.Log("エレベーターの電源のカギを見つけた");
                        break;
                    case "Key_Unown":
                        Item[5] = true;
                        Debug.Log("謎のカギを見つけた");
                        break;
                }
                Have_Item++;
            }
        }
    }

    //アイテムから離れたとき
    private void OnTriggerExit2D(Collider2D collision)
    {
        Flag = false;
    }
    #endregion

    #region アイテムストレージ
    [SerializeField]
    private GameObject Menu;
    [SerializeField]
    private GameObject Menu2;
    private bool Menu_Open;


    private void Item_Inventory()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Menu_Open == false)
            {
                Menu_Open = true;
                Menu.gameObject.SetActive(true);
                Menu.gameObject.GetComponent<MenuController>().Start_Button();
                Move_direction = 0;
                Debug.Log("Open");
            }
            else
            {
                Menu_Open = false;
                Menu.gameObject.SetActive(false);
                Debug.Log("Close");
            }
        }
    }
    #endregion
}
