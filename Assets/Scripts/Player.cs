using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    private int health;
    private int mana;
    private SpellBook book;
    private SpellFocus focus;

    // Start is called before the first frame update
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        book = new SpellBook();
        book.PopulateSpells();

        focus =  gameObject.GetComponent<SpellFocus>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;
        bool m_Fire = Input.GetButtonDown("Fire1");
        if (m_Fire)
        {
            //CmdCast("Fireball");
            Graph _s = book.spells["Fireball"];
            focus.castSpell(_s);
        }

    }


}
