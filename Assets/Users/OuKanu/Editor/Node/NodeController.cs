using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NodeController
{
    public NodeView view;
    public NodeData data;

    public abstract void CreateNode(int nodeId);

    public abstract void Draw();

}
