using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> StagePrefabs = new List<GameObject>();

    public List<GameObject> Stages;

    private void Awake()
    {
        Stages = new List<GameObject>();
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
