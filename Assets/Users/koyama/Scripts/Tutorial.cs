using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public bool wall = false;

    [SerializeField]
    private Text text;
    [SerializeField]
    private GameObject _text;

    public void Door()//初期部屋のドア
    {
        _text.SetActive(true);
        text.text = "ドアは壊れて開かない";
        //テキスト ドアは壊れて開かない
    }
    public void Wall()//306の壁
    {
        if(wall == false)
        {
            _text.SetActive(true);
            text.text = "少し壊れている…?";
            //text　少し壊れている
        }
        else//破壊後
        {
            wall = true;
            //破壊前の壁非表示

            //破壊後の壁を表示
            return;
        }
    }
}
