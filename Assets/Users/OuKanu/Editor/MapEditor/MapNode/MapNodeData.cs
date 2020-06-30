using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 一つのRoomを表すデータ
/// </summary>
public class MapNodeData : NodeData
{
    public int m_RoomID;
    public List<MapNodeData> LinkedMapNode;
}
