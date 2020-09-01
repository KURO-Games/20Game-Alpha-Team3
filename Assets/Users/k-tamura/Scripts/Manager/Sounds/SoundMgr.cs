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
    /// <summary>
    /// 再生時間を任意の形式で返すプログラム
    /// </summary>
    /// <typeparam name="T">default:long, float, double</typeparam>
    /// <returns></returns>
    public static T BGMPlayTime<T>()
    {
        object ret = null;
        long _BGMTime = Instance.bgm.time;

        if (typeof(T) == typeof(float))
            ret = (float)_BGMTime;
        else if (typeof(T) == typeof(double))
            ret = (double)_BGMTime;
        else
            ret = _BGMTime;
        return (T)ret;
    }

}
