using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Node {

    public List<Edge> Edges { get { return edges; } }

    protected List<Edge> edges;

    public Node prev = null;
    public string name = null;

    public Node(string nname) {
        name = nname;
        edges = new List<Edge>();
    }

    public Edge Connect(Node node, float weight = 1f)
    {
        Debug.Log("Connecting "+this.name + " with: "+node.name);
        var e = new Edge(this, node, weight);
        edges.Add(e);
        return e;
    }

    

}


