using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


/// <summary>
/// 地図編集エディター
/// </summary>
public class MapEditor : EditorWindow, IHasCustomMenu
{

    private MapData currentEditingMap;


    [MenuItem("Levels/MapEditor")]
    private static void Open()
    {
        GetWindow<MapEditor>();

    }




    public void AddItemsToMenu(GenericMenu menu)
    {
        throw new System.NotImplementedException();
    }


    private void OnGUI()
    {
        
    }


}
