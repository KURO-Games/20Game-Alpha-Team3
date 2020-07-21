using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadMgr : SingletonMonoBehaviour<SceneLoadMgr>
{
    public static void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
