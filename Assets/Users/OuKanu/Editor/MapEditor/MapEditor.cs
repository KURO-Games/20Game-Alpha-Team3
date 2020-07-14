using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.ComponentModel;
using UnityEditor.Experimental;
using Packages.Rider.Editor.Util;

/// <summary>
/// 地図編集エディター
/// </summary>
public class MapEditor : EditorWindow, IHasCustomMenu
{

    Action<bool> _callback;

    //いま編集しているマップ;
    private MapData currentEditingMap;

    //エディターで表示するノード
    private List<MapNodeData> rooms = new List<MapNodeData>();


    Vector2 scrollPos;


    [MenuItem("Levels/MapEditor")]
    private static void Open()
    {
        GetWindow<MapEditor>();
    }




    public void AddItemsToMenu(GenericMenu menu)
    {
       
    }


    private void OnGUI()
    {
        currentEditingMap = EditorGUILayout.ObjectField("Source", currentEditingMap, typeof(MapData), false) as MapData;
        if (currentEditingMap == null)
        {
            if (GUILayout.Button("Create"))
            {
                CreateMapData();
                if (currentEditingMap == null)
                {
                    return;
                }
                ImportMapData();
            }
        }
        if (!EditorUtility.IsDirty(currentEditingMap) && currentEditingMap != null)
        {
            
            ImportMapData();
            EditorUtility.SetDirty(currentEditingMap);
        }
        if (currentEditingMap == null) 
        { 
            return; 
        }

        

        scrollPos = GUI.BeginScrollView(new Rect(0, 100, position.width, position.height - 100), scrollPos, new Rect(0, 0, 1000, Screen.height));

        BeginWindows();

        for (int i = 0; i < rooms.Count; i++)
        {
            DrawNode(rooms[i]);
        }


        EndWindows();

        GUI.EndScrollView();



        //データを保存する
        if (GUILayout.Button("Save") == false) { return; }
        AssetDatabase.StartAssetEditing();
        currentEditingMap.mapNodes.Clear();
        for (int i = 0; i < rooms.Count; i++)
        {
            currentEditingMap.mapNodes.Add(rooms[i]);
        }
        AssetDatabase.StopAssetEditing();
        EditorUtility.SetDirty(currentEditingMap);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private void DrawNode(MapNodeData mapNodeData)
    {
        GUI.skin = mapNodeData.skin;
        mapNodeData.nodeRect = GUI.Window(mapNodeData.windowID, mapNodeData.nodeRect, callBack, mapNodeData.nodeName);
        GUI.skin = null;
    }

    private void callBack(int id)
    {
        GUI.DragWindow();
    }

    /// <summary>
    /// 新しいマップデータを作成
    /// </summary>
    private void CreateMapData()
    {
        //ファイルpathを作成
        string targetFilePath = EditorUtility.SaveFilePanel("Create New MapData", "Assets", "NewMapData", "asset");

        //cancelした場合
        if(targetFilePath == "")
        {
            Debug.LogWarning("Create Cancel");
            return;
        }

        //プロジェクトpathと比較
        string datapath = Application.dataPath;
        if (!targetFilePath.StartsWith(datapath))
        {
            //プロジェクト以外のpathを拒否
            Debug.LogError("Please Assign a path under this project's assets directory");
            return;
        }

        //path再編成
        targetFilePath = "Assets/" + targetFilePath.Substring(datapath.Length);


        //Instance作成
        MapData data = CreateInstance<MapData>();

        //ファイル作成
        try
        {
            AssetDatabase.CreateAsset(data, targetFilePath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
        catch (Exception)
        {
            return;
        }
       
        
        try
        {
            //今編集しているデータとして指定
            currentEditingMap = AssetDatabase.LoadAssetAtPath(targetFilePath, typeof(MapData)) as MapData;
        }
        catch (NullReferenceException)
        {
            //例外チェック
            Debug.LogError("Failed to create asset");
            throw;
        }
        
    }

    private void ImportMapData()
    {
        if(currentEditingMap == null)
        {
            return;
        }
        if(currentEditingMap.mapNodes == null)
        {
            currentEditingMap.mapNodes = new List<MapNodeData>();
        }
        rooms.Clear();
        for (int i = 0; i < currentEditingMap.mapNodes.Count; i++)
        {
            MapNodeData data = new MapNodeData();
            data.windowID = currentEditingMap.mapNodes[i].windowID;
            data.skin = currentEditingMap.mapNodes[i].skin;
            data.nodeRect = currentEditingMap.mapNodes[i].nodeRect;
            data.nodeName = currentEditingMap.mapNodes[i].nodeName;
            
            rooms.Add(data);
        }

        
        
    }


    public void InitialNode(ref MapNodeData node)
    {

        node.nodeRect = new Rect(50, 50, 250, 250);
        node.skin = Resources.Load<GUISkin>("EventNode");
    }



}
