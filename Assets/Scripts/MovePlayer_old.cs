using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerOld : MonoBehaviour {
    public float speed = 5;
    public float gravity = -5;
    public float rotSpeed = 180;

    List<Vector3> pos = new List<Vector3>();
    float velocityY = 0;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        Color c1 = Color.blue;
        Color c2 = Color.blue;
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 1.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.widthMultiplier = 0.2f;
        lineRenderer.colorGradient = gradient;
    }

    // Update is called once per frame
    void Update () {
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

        if (controller.isGrounded)
        {
            velocityY = 0;
        }

        pos.Add(this.gameObject.transform.position);
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = pos.Count;
        lineRenderer.SetPositions(pos.ToArray());
    }
}
