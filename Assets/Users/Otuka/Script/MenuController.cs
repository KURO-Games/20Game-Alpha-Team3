using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button Start_Set_Button;
    [SerializeField]
    public GameObject[] button;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Start_Button()
    {
        Debug.Log("aaaa");
        Start_Set_Button.Select();
    }
}
