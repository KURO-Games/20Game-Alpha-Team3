using Assets.Users.OuKanu.Model.Map;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 部屋のプレハブにアタッチして、中身の各出入口を取得、計算
/// </summary>
public class RoomView : MonoBehaviour
{
    public Texture texture;
    public Sprite sprite;


    public RoomView()
    {
        roomWindow = new RoomEditorModel();
    }

    public RoomEditorModel roomWindow;

    public void LoadDataToRuntime(RoomAssetData staticRoomData)
    {
       
        foreach (var offset in staticRoomData.entrypointoffsets)
        {
            roomWindow.m_data.entries.Add(offset);

            roomWindow.m_rect.entryrect.Add(new Rect(offset * 10f, new Vector2(50, 50)));
        }

        roomWindow.m_data.RoomName = staticRoomData.roomName;
        roomWindow.m_rect.m_NodeRect = new Rect(Vector2.zero, new Vector2(250,250));
        roomWindow.m_rect.messageRect = new Rect(roomWindow.m_rect.m_NodeRect.center, new Vector2(150, 50));
        roomWindow.skin = Resources.Load<GUISkin>("EventNode");
        roomWindow.windowID = 0;

        texture = Resources.Load<Texture>("GUI/EntryPoint/Grid");
    }

    public void DrawNode()
    {
        GUI.skin = roomWindow.skin;
        roomWindow.m_rect.m_NodeRect = GUI.Window(roomWindow.windowID, roomWindow.m_rect.m_NodeRect, Window, roomWindow.m_data.RoomName);
        GUI.skin = null;
    }

    private void Window(int id)
    {
        
        Rect ms = new Rect(Vector2.zero, new Vector2(50, 50));
        GUI.Box(ms,GUIContent.none);
        for (int i = 0; i < roomWindow.m_data.entries.Count; i++)
        {
            Rect re = new Rect(new Vector2(0,100), new Vector2(50, 50)); 
            GUI.Box(re,texture,GUIStyle.none);
        }
        

        GUI.DragWindow();
    }

}
