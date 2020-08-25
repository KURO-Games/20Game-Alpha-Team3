using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corridor : MonoBehaviour
{
    public bool PottedPlant;

    private void Awake()
    {
        PottedPlant = false;
    }
    //鍵取得イベント
    public void KeyEvent()
    {
        if(PottedPlant == true)
        {
            return;
        }
        else
        {
            //どこかの鍵をアイテムインベントリに入れる
            PottedPlant = true;
            //ドアの音を入れる
        }
    }
    //連絡通路移動後のイベント
    public void GameEnd()
    {
        //リザルト画面呼出し
    }
}
