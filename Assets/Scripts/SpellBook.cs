using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBook
{
    public Dictionary<string, Graph> spells;

    public SpellBook()
    {
        spells = new Dictionary<string, Graph>();
    }

    public void AddSpell(string spellName, Graph g)
    {
        spells.Add(spellName, g);

    }

    // Update is called once per frame
    public void PopulateSpells()
    {
        Graph spell = new Graph();

        CommandPattern.Command n1 = new CommandPattern.Create("CREATE_ORB", spell);
        CommandPattern.Command n2 = new CommandPattern.Move("MOVE_ORB", spell);
        CommandPattern.Command n3 = new CommandPattern.Command("EXPLODE", spell);
        n1.Connect(n2);
        n2.Connect(n3);
        spell.start.Connect(n1);

        spells.Add("Fireball", spell);
    }
}
