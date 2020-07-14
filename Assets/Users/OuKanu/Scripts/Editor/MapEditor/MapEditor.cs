using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.ComponentModel;
using UnityEditor.Experimental;
using Packages.Rider.Editor.Util;
using Oukanu.Node;
using Assets.Users.OuKanu.Model.Map;

/// <summary>
/// 地図編集エディター
/// </summary>
public class MapEditor : EditorWindow, IHasCustomMenu
{

   

    //いま編集しているマップ;
    private MapAssetData currentEditingMap;

    //エディターで表示するノード
    private List<RoomView> rooms = new List<RoomView>();


    Vector2 scrollPos;

    bool isimported = false;

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

        currentEditingMap = EditorGUILayout.ObjectField("Source", currentEditingMap, typeof(MapAssetData), false) as MapAssetData;
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
        if (!isimported && currentEditingMap != null)
        {
            
            ImportMapData();
            //EditorUtility.SetDirty(currentEditingMap);
            isimported = true;
        }
        if (currentEditingMap == null) 
        { 
            return; 
        }

        

        scrollPos = GUI.BeginScrollView(new Rect(0, 100, position.width, position.height - 100), scrollPos, new Rect(0, 0, 1000, Screen.height));

        BeginWindows();

        for (int i = 0; i < rooms.Count; i++)
        {
           rooms[i].DrawNode();
        }


        EndWindows();

        GUI.EndScrollView();



        //データを保存する
        if (GUILayout.Button("Refresh") == false) { return; }

        isimported = false;
        //AssetDatabase.StopAssetEditing();
        
        //EditorUtility.SetDirty(currentEditingMap);
        //AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
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
        MapAssetData data = CreateInstance<MapAssetData>();

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
            currentEditingMap = AssetDatabase.LoadAssetAtPath(targetFilePath, typeof(MapAssetData)) as MapAssetData;
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
        //if(currentEditingMap.Rooms == null)
        //{
        //    currentEditingMap.mapNodes = new List<MapNodeData>();
        //}
        //rooms.Clear();
        for (int i = 0; i < currentEditingMap.Rooms.Count; i++)
        {
            RoomView view = new RoomView();
            view.LoadDataToRuntime(currentEditingMap.Rooms[i]);
            //view.BuildEditorModel();
            rooms.Add(view);
        }

        
        
    }


    public void InitialNode(ref RoomEditorModel node)
    {

        node.m_rect.m_NodeRect = new Rect(50, 50, 250, 250);
        node.skin = Resources.Load<GUISkin>("EventNode");
    }



}
