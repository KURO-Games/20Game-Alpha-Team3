using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEntryPoint : MonoBehaviour
{
    [SerializeField]
    private Transform targetEntryPoint;


    public Vector3 GetTargetStageEntryPostion()
    {
        return targetEntryPoint.position;
    }

    
}
