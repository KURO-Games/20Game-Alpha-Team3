using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectingPassage : MonoBehaviour
{
    [SerializeField]
    private Text text;
    [SerializeField]
    private GameObject _text;

    public void Start()
    {
        UpFloor();
    }

    //4階より上に行くとき
    public void UpFloor()
    {
        _text.SetActive(true);
        text.text="鉄骨が邪魔でこれ以上、上に行けないようだ";
        //テキスト 鉄骨が邪魔でこれ以上、上に行けないようだ
    }
    //2階より下に行くとき
    public void DownFloor()
    {
        _text.SetActive(true);
        text.text = "鉄骨が邪魔でこれ以上、下に行けないようだ";
        //テキスト 鉄骨が邪魔でこれ以上、下に行けないようだ
    }
}
