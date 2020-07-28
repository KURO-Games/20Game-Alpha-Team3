using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room306 : MonoBehaviour
{
    public bool Candle;
    public bool Match;

    public void Awake()
    {
        Candle = false;
        Match = false;
    }
    //吹き出し
    public void SpeechBubble()
    {
        if(Candle == false&&Match ==false)
        {
            //吹き出し表示
        }
        else
        {
            return;
        }
    }
    //蠟燭取得
    public void GetCandle()
    {
        Candle = true;
        //吹き出し非表示
        //蠟燭をアイテムインベントリに入れる
    }
    //マッチ取得
    public void GetMatch()
    {
        Match = true;
        //吹き出し非表示
        //マッチをアイテムインベントリに入れる
    }
    //鍵入手後のイベント
    public void GameEnd()
    {
        //リザルト画面呼び出し
    }
    //連絡通路移動後のイベント
    public void Open()
    {
        //ドアが開いた状態にする
    }
}
