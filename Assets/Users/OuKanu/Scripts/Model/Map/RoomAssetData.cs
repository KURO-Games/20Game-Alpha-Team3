﻿using System.Collections;
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
    public Vector2 offset;
    public List<EntryPointData> entrypointoffsets = new List<EntryPointData>();

}
