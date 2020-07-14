using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 一つの部屋のプレハブ情報を格納するデータクラス
/// </summary>
public class RoomData : ScriptableObject
{
    public GameObject RoomPrefab;
    public int roomID;

}
