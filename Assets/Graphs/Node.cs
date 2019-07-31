using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Node 
{

    public List<Edge> Edges { get { return edges; } }

    protected List<Edge> edges;

    public Node prev = null;
    public string nname = null;

    public Node()
    {
        this.nname = "NoName";
        this.edges = new List<Edge>();
    }

    public Node(string nname) {
        this.nname = nname;
        this.edges = new List<Edge>();
    }

    public Edge Connect(Node node, float weight = 1f)
    {
        Debug.Log("Connecting "+this.nname + " with: "+node.nname);
        var e = new Edge(this, node, weight);
        edges.Add(e);
        return e;
    }

    

}


