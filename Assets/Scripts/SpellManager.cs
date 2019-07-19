using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{

    [SerializeField] public Dictionary<string, Graph> spells;
    // Start is called before the first frame update
    void Start()
    {
        spells = new Dictionary<string, Graph>();
        Graph spell = new Graph();
        spells.Add("Fireball", spell);

        CommandPattern.Command n1 = new CommandPattern.Create("CREATE_ORB", spell);
        CommandPattern.Command n2 = new CommandPattern.Move("MOVE_ORB", spell);
        CommandPattern.Command n3 = new CommandPattern.Command("EXPLODE", spell);
        n1.Connect(n2);
        n2.Connect(n3);
        spell.start.Connect(n1);
        Debug.Log("Spell manager started!");
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
