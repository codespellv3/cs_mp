using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MovePlayer : NetworkBehaviour
{
    [SyncVar]
    public float speed;

    [SyncVar]
    public string playerName;

    [SyncVar]
    public int health;

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (isLocalPlayer)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(h, 0.0f, v);
            rb.AddForce(movement*speed);
        } else
        {
            Debug.Log("Not controlled by local player!");
            return;
        }


    }
}
