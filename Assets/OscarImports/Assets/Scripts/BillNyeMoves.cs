using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillNyeMoves : MonoBehaviour
{
    [SerializeField] int moveSpeed;
    [SerializeField] Vector3 velocity;
    public Vector3 Velocity { get { return velocity; } set { } }
    [SerializeField] CharacterController cc;
    private float xRandom;
    private float zRandom;


    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component
        //rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        velocity.y = -0.1f;
        // Set initial random velocity
        //velocity = new Vector3(Random.Range(minSpeed, maxSpeed), 0f, Random.Range(minSpeed, maxSpeed));
    }

    void FixedUpdate()
    {
        // Update velocity randomly
        xRandom = Random.Range(-0.1f, 0.1f);
        zRandom = Random.Range(-0.1f, 0.1f);
        velocity += new Vector3(xRandom, 0, zRandom);
        if (velocity.x > 1 || velocity.x < -1)
        {
            velocity.x -= xRandom;
        }
        if (velocity.z > 1 || velocity.z < -1)
        {
            velocity.z -= zRandom;
        }
        if (velocity.magnitude > 0.1f)
        {
            transform.LookAt(transform.position + new Vector3(velocity.x, 0, velocity.z));
        }

        // Limit velocity to min/max speed
        cc.Move(velocity * moveSpeed * Time.deltaTime);
    }
}
