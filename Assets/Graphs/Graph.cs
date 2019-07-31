using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : ScriptableObject
{

    public Node start;
    public Dictionary<string, GameObject> reg;

    public Graph()
    {
        reg = new Dictionary<string, GameObject>(); 
        start = new Node("START");
        start.prev = null;
    }

    public static Graph Clone(Graph g)
    {
        string serialized = JsonUtility.ToJson(g);
        Debug.Log(serialized);
        return JsonUtility.FromJson<Graph>(serialized);
    }

    public string PrintString()
    {
        string s = "Graph(";
        foreach (Node n in this.Traverse())
        {
            if (n == null)
                continue;
            s += n.nname + ",";

        }
        s += "END";
        return s;
    }

    public IEnumerable<Node> Traverse()
    {
        int count = 0;
        int MAX_ITER = 100;
        Debug.Log("Starting graph traversal");
        Stack<Node> actives = new Stack<Node>();
        actives.Push(start);
        while(actives.Count > 0)
        {
            count += 1;
            Node n = actives.Pop();
            yield return n;
            foreach (Edge e in n.Edges)
            {
                Debug.Log("Adding node " + e.To.nname);
                actives.Push(e.To);
            }
            if (count > MAX_ITER)
            {
                break;
            }
                
            
        }
        Debug.Log("End of traversal");
    }

}


