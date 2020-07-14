using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Users.OuKanu.Model.Map
{
    public struct RoomData
    {
        
        public string RoomName;

        public List<Vector2> entries;
    }

    public struct RectData
    {
        public Rect m_NodeRect;
        public Rect messageRect;
        public List<Rect> entryrect;
    }
    public class RoomEditorModel
    {
        public RoomEditorModel()
        {
            m_data.entries = new List<Vector2>();
            m_rect.entryrect = new List<Rect>();
        }
        public int windowID;
        public GUISkin skin;

        public RoomData m_data;
        public RectData m_rect;
    }
}
