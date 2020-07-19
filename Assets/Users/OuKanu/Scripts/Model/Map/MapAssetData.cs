using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAssetData : ScriptableObject
{
    public List<RoomAssetData> Rooms = new List<RoomAssetData>();

    public Dictionary<string, RoomAssetData> RoomMap;
    public Dictionary<int, EntryPointData> EntryPointMap;
}
