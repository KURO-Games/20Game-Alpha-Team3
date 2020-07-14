using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPointHolder : MonoBehaviour
{
    [SerializeField]
    List<StageEntryPoint> entryPoints = new List<StageEntryPoint>();

    internal List<StageEntryPoint> GetEntryPoints()
    {
        return entryPoints;
    }
}
