using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField]
    CriAtomSource bgm=null;

    // Start is called before the first frame update
    void Start()
    {
        bgm.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
