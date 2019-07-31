using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CastSpell : NetworkBehaviour
{
    public SpellManager sm;
    private GameObject orb;

    void doCast(Graph spell)
    {
        
        foreach (Node n in spell.Traverse())
        {
            CommandPattern.Command c = (n as CommandPattern.Command);
            if (c != null)
            {

                Dictionary<string, object> args = new Dictionary<string, object>();
                args.Add("primitive", PrimitiveType.Sphere);
                args.Add("position", transform.position);
                args.Add("direction", transform.forward * 2);
                args.Add("object", "orb");


                c.Execute(null, args);
                if (c.nname == "EXPLODE")
                {

                }

            }


        }
     }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        GameObject smo = GameObject.Find("SpellManager");
        sm = smo.GetComponent<SpellManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            bool m_Fire = Input.GetButtonDown("Fire1");
            if  (m_Fire)
            {
                doCast(sm.spells["Fireball"]);
            }
            
        }
    }
}
