using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Graph {

    public Node start;
    public Dictionary<string, GameObject> reg;

    public Graph()
    {
        reg = new Dictionary<string, GameObject>(); 
        start = new Node("START");
        start.prev = null;
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
                Debug.Log("Adding node " + e.To.name);
                actives.Push(e.To);
            }
            if (count > MAX_ITER)
            {
                break;
            }
                
            
        }
    }

}


