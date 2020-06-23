using System.Collections;
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
    }

    //キー操作
    private void Controller()
    {
        Pos = transform.position;
        scale = transform.localScale;
        //右
        if (Input.GetKey(KeyCode.D))
        {
            //向き指定
            Move_direction = 1;
            //移動
            Move_Controller();
        }
        //左
        if (Input.GetKey(KeyCode.A))
        {
            //向き指定
            Move_direction = -1;
            //移動
            Move_Controller();
        }
        //停止
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("aaaa");
    }
}
