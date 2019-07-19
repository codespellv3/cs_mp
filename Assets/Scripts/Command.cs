using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
            Debug.Log("Executed " + this.name);
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
        public override void Execute(GameObject obj, Dictionary<string, object> args)
        {
            //Move the box
            GameObject orb = GameObject.CreatePrimitive(
(UnityEngine.PrimitiveType)args["primitive"]
                    );
            orb.AddComponent<Rigidbody>();
            orb.transform.position = (UnityEngine.Vector3)args["position"];
            spell.reg.Add("orb",orb);

            base.Execute(obj, args);

        }
    }

    public class Move: Command
    {
        public Move(string nname, Graph aspell) : base(nname, aspell)
        {

        }

        //Called when we press a key
        public override void Execute(GameObject obj, Dictionary<string, object> args)
        {
            GameObject _aObj = spell.reg[args["object"].ToString()];
            Vector3 _aDir = (Vector3)args["direction"];
            if (_aObj)
            {
                _aObj.GetComponent<Rigidbody>().velocity = _aDir;
            }

            base.Execute(obj, args);
            
        }
    }


}
