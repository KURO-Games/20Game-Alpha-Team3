using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageManager : MonoBehaviour
{
    [HideInInspector]
    public StageManager instance;

    [SerializeField]
    List<RoomPointHolder> StagePrefabs = new List<RoomPointHolder>();

    [HideInInspector]
    public List<GameObject> Stages;

    Dictionary<int, StageEntryPoint> map = new Dictionary<int, StageEntryPoint>();

    private void Awake()
    {
        instance = this;
        Stages = new List<GameObject>();
    }

    private void Start()
    {
        foreach (var item in StagePrefabs)
        {
            foreach (var entry in item.GetEntryPoints())
            {
                map.Add(entry.MyCode, entry);
            }
        }

        foreach (var item in map)
        {
            if (map.ContainsKey(item.Value.PairCode))
            {
                item.Value.targetpoint = map[item.Value.PairCode];
            }
            
        }

    }

    public void CreateStage(GameObject stageOrigin)
    {
        var stage = Instantiate<GameObject>(stageOrigin);
        Stages.Add(stage);
        stage.SetActive(false);
    }

    public void LoadStage(GameObject stage,Vector3 position)
    {
        stage.transform.position = position;
        stage.SetActive(true);
    }

    public void UnloadStage(GameObject stage)
    {
        stage.SetActive(false);
    }

    public void DeleteStage(GameObject stage)
    {
        Stages.Remove(stage);
        Destroy(stage);
    }

}
