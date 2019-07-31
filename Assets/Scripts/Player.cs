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
            CmdFire();
            //Graph _s = book.spells["Fireball"];
            //focus.castSpell(_s);
        }

    }

    [Command]
    void CmdFire()
    {
        Debug.Log("FIRING!!!");
        GameObject spell =  (GameObject)Resources.Load("prefabs/BaseSpell", typeof(GameObject));
        GameObject clone = Instantiate(spell, transform.position,
            transform.rotation);
        clone.AddComponent<Rigidbody>();

        clone.GetComponent<Rigidbody>().velocity = transform.forward;
        NetworkServer.Spawn(clone, System.Guid.NewGuid());

    }
}
