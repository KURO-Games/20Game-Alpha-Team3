using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageManager : MonoBehaviour
{
    public Cinemachine.CinemachineConfiner cameraconfiner;
    public FadeInCanvas fadecanvas;
    
    [HideInInspector]
    public static StageManager instance;

    [SerializeField]
    List<RoomPointHolder> StagePrefabs = new List<RoomPointHolder>();

    [HideInInspector]
    public List<GameObject> Stages;

    [HideInInspector]
    public List<StageEntryPoint> points = new List<StageEntryPoint>();

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


    public IEnumerator MoveToRoom(StageEntryPoint point,Transform player)
    {
        //diable move
        var control = player.GetComponent<UnityChan2DController>();
        control.SetPlayerControl(false);
        //start fadein
        yield return StartCoroutine(fadecanvas.DoFadeIn(1,1));
        //teleport player
        player.transform.position = point.m_inTransform.position;
        //set room camera confiner
        var confiner = point.GetComponentInParent<RoomPointHolder>().cameraBound;
        if (confiner)
            cameraconfiner.m_BoundingShape2D = confiner;

        //start fadeout
        yield return StartCoroutine(fadecanvas.DoFadeIn(1, 0));
        //enable move
        control.SetPlayerControl(true);

    }

}
