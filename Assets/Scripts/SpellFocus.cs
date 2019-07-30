using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SpellFocus : NetworkBehaviour
{
    private List<Graph> _stack;

    public SpellFocus()
    {
        _stack = new List<Graph>();
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
    }

    // Schedule spell for casting in the update
    public void castSpell(Graph g) {

        _stack.Add(Graph.Clone(g));
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;

        // Send all waiting spell to the executor coRutine
        foreach (Graph g in _stack)
        {
            StartCoroutine(DoCast(g));
        }

        _stack.Clear();

    }

    IEnumerator DoCast(Graph spell)
    {

        foreach (Node n in spell.Traverse())
        {
            CommandPattern.Command c = (n as CommandPattern.Command);
            if (c == null)
                continue;
            
            Dictionary<string, object> args = new Dictionary<string, object>();
            args.Add("primitive", PrimitiveType.Sphere);
            args.Add("position", transform.position);
            args.Add("direction", transform.forward * 2);
            args.Add("object", "orb");

            //if (c.name == "EXPLODE")
            //{

//            }
            c.Execute(null, args);
            yield return new WaitForSeconds(.1f);


            


        }
    }
}
