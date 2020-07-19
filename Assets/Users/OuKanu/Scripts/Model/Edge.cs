using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Oukanu.Node
{
    public struct Edge
    {
        public Edge(Vector2 _start, Vector2 _end)
        {
            startPoint = _start;
            endPoint = _end;
        }
        Vector2 startPoint, endPoint;
        public void Draw()
        {
            Handles.DrawLine(startPoint, endPoint);
        }

    }

}

