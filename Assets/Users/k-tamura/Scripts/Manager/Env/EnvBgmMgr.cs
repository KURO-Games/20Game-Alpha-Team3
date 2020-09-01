using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvBgmMgr : MonoBehaviour
{
    public static bool BGMoneShot;

    private void Start()
    {
        BGMoneShot = false;
    }
    // Start is called before the first frame update



    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Stage1"&&!BGMoneShot)
        {
            SoundMgr.PlayBGM(1);
            BGMoneShot = true;
        }
    }
}
