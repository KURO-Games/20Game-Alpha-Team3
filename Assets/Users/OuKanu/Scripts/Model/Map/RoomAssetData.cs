using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 一つの部屋のプレハブ情報を格納するデータクラス
/// </summary>
/// 
[CreateAssetMenu(menuName ="RoomAsset")]
public class RoomAssetData : ScriptableObject
{
    public string roomName;

    public List<Vector2> entrypointoffsets = new List<Vector2>();

}
