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
    private bool entrypoint = false;

    public EntryPointType entryPointType;

    public int PairCode;
    public int MyCode;

    private PlayerStageControl player;

    public StageEntryPoint targetpoint;

    public Vector3 RelativePos
    {
        get => transform.localPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player = collision.GetComponent<PlayerStageControl>();
            player.entrypoint = this;
            if (entryPointType == EntryPointType.NeedActive)
            {
                
                return;
            }
            
            if(entryPointType == EntryPointType.AutoTrigger)
            {
                if (entrypoint) return;
                Activate(player.transform);
                return;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            player.entrypoint = null;
            player = null;
            entrypoint = false;
        }
    }

    public void Activate(Transform teleportItem)
    {
        if (targetpoint != null)
        {
            teleportItem.position = targetpoint.transform.position;
            targetpoint.entrypoint = true;
        }
    }
}
