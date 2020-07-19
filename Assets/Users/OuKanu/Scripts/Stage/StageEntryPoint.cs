using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntryPointType
{
    AutoTrigger,
    NeedActive
}


public class StageEntryPoint : MonoBehaviour
{
    

    public EntryPointType entryPointType;

    public int PairCode;
    public int MyCode;

    private PlayerStageControl player;

    public StageEntryPoint targetpoint;

    public Transform m_inTransform;


    public Vector3 RelativePos
    {
        get => transform.localPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(targetpoint == null)
        {
            Debug.LogError("No target Point");
            return;
        }

        Debug.Log("triggered " + collision.name);
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Player In!");
            player = collision.GetComponent<PlayerStageControl>();
            if(player == null)
            {
                Debug.LogError("Get Player False");
                return;
            }
            if (entryPointType == EntryPointType.NeedActive)
            {
                player.entrypoint = this;
                player.DisplayUI(true);
                return;
            }
            
            if(entryPointType == EntryPointType.AutoTrigger)
            {
                
                Activate(player.transform);
                return;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Somthing Exit!");
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Player Exit!");
            player.entrypoint = null;
            if(entryPointType == EntryPointType.NeedActive)
            {
                player.DisplayUI(false);
            }
            player = null;
            
        }
    }

    public void Activate(Transform teleportItem)
    {
        Debug.Log("Start Transition!");
        if (targetpoint == null)
        {
            Debug.LogError("Transform reference Lost!");
            return;
        }
        else
        {
            StartCoroutine(StageManager.instance.MoveToRoom(targetpoint, teleportItem));
        }
    }
}
