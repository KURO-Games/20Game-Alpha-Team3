﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    void Update()
    {
        Transform transform = this.transform;
        Controller();
        animator.SetFloat("Move", Move_direction);
        //テスト
        Test_Gimmick();
    }
    #region 移動処理
    //キー操作
    private void Controller()
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

    #region テスト
    private bool Flag = false;
    private GameObject Gimmick_Object;
    //ギミックの判定やアイテムの判定をどうするかわからないけどとりあえずおいとく
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Flag = true;
        Gimmick_Object = collision.gameObject;
        Debug.Log("何かあるかも？");
    }

    private void Test_Gimmick()
    {
        if (Flag == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Destroy(Gimmick_Object);
                //何かしらの処理
                Debug.Log(Gimmick_Object.name + "を見つけた");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Flag = false;
    }
    #endregion
}
