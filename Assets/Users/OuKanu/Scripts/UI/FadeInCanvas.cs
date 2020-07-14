using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInCanvas : MonoBehaviour
{
    public float alpha = 0f;

    private CanvasGroup mCanvasGroup;

    private float deltaAlpha = 0f;


    public void DoFadeIn(float time)
    {
        deltaAlpha = 1.0f / time;
    }

    public void DoFadeOut(float time)
    {
        deltaAlpha = -1.0f / time;
    }

    public void SetFadeAlpha(float alphaPercent)
    {
        deltaAlpha = 0;
        alpha = alphaPercent / 100f;
        alpha = Mathf.Clamp01(alpha);
    }

    
    void Start()
    {
        mCanvasGroup = GetComponent<CanvasGroup>();
    }

    
    void Update()
    {
        alpha += deltaAlpha;
        alpha = Mathf.Clamp01(alpha);
        mCanvasGroup.alpha = alpha;
    }
}
