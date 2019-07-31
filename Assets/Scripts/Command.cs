using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mirror;
namespace CommandPattern
{
    //The parent class
    public class Command: Node
    {
        protected Graph spell;
        public Command(string nname, Graph aspell) : base(nname){
            spell = aspell;
        }

        //Move and maybe save command
        public virtual void Execute(GameObject obj, Dictionary<string, object> args)
        {
            //Save the command
            Debug.Log("Executed " + this.nname);
        }

    }


    //
    // Child classes
    //

    public class Create : Command
    {
        public Create(string nname, Graph aspell) : base(nname, aspell)
        {

        }

        //Called when we press a key
        public override void Execute(GameObject spellGO, Dictionary<string, object> args)
        {
            Debug.Log("Executing Create" );
            //Create the object

            spellGO.AddComponent<Rigidbody>();
            /*
            objSpell.AddComponent<MeshFilter>();
            objSpell.AddComponent<SphereCollider>();
            objSpell.AddComponent<MeshRenderer>();
            objSpell.AddComponent<NetworkIdentity>();
            objSpell.AddComponent<NetworkTransform>();
            GameObject primitive = GameObject.CreatePrimitive(
(UnityEngine.PrimitiveType)args["primitive"]
                    );
            Object.Destroy(primitive);
            objSpell.GetComponent<MeshFilter>().mesh = primitive.GetComponent<MeshFilter>().mesh;
            objSpell.transform.position = (UnityEngine.Vector3)args["position"];
            spell.reg.Add("orb", objSpell);
            Debug.Log("Created spell object" + objSpell.ToString());
            ClientScene.RegisterPrefab(objSpell);
            NetworkServer.Spawn(objSpell);
            */
            base.Execute(spellGO, args);

        }
    }

    public class Move: Command
    {
        public Move(string nname, Graph aspell) : base(nname, aspell)
        {

        }

        //Called when we press a key
        public override void Execute(GameObject spellGO, Dictionary<string, object> args)
        {
            //GameObject _aObj = spell.reg[args["object"].ToString()];
            Vector3 _aDir = (Vector3)args["direction"];
            if (spellGO)
            {
                spellGO.GetComponent<Rigidbody>().velocity = _aDir;
            }

            base.Execute(spellGO, args);
            
        }
    }


}
