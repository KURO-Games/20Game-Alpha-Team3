using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : SingletonMonoBehaviour<SoundMgr>
{
    [SerializeField]
    CriAtomSource bgm = null;
    [SerializeField]
    CriAtomSource Se = null;

    public static void PlayBGM(int cueID)
    {
        Instance.bgm.Play(cueID);
    }
    public static void PlaySE(int cueID)
    {
        Instance.Se.Play(cueID);
    }
    public static void StopBGM(float Time)
    {
        Instance.bgm.Stop();
    }
    public static CriAtomSource.Status BGMStatus()
    {
        return Instance.bgm.status;
    }
    public static CriAtomSource.Status SEStatus()
    {
        return Instance.Se.status;
    }
    //public static void 


}
