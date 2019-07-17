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

    public float gravity = -5;
    public float rotSpeed = 180;
    float velocityY = 0;
    CharacterController controller;
    Camera avatarCamera;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        controller = GetComponent<CharacterController>();
        Rigidbody rb = GetComponent<Rigidbody>();

        avatarCamera = GetComponent<Camera>();
        avatarCamera.enabled = true;


    }

    // Update is called once per frame
    void Update()
    {
        
        if (isLocalPlayer)
        {
            velocityY += gravity * Time.deltaTime;

            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            input = input.normalized;

            Vector3 temp = Vector3.zero;

            if (input.z > 0)
            {
                temp += transform.forward;
            }
            else if (input.z < 0)
            {
                temp += transform.forward * -1;
            }

            if (input.x > 0)
            {
                transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
            }
            else if (input.x < 0)
            {
                transform.Rotate(0, - rotSpeed * Time.deltaTime, 0);
            }

            Vector3 velocity = temp * speed;
            velocity.y = velocityY;
 
            controller.Move(velocity * Time.deltaTime);


        }
     }
}
