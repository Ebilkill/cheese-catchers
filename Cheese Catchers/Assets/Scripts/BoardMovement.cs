using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoardMovement : MonoBehaviour
{

    public float maxSpeed;
    public float maxSidewaysSpeed;

    // Movement when player holds an arrow key
    public Vector3 arrowMove;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Set the maximum velocity
        Vector3 velocity = GetComponent<Rigidbody>().velocity;

        float zSpeed = velocity.z;
        zSpeed *= (float)Math.Min(1, maxSpeed / Math.Sqrt(GetComponent<Rigidbody>().velocity.z * GetComponent<Rigidbody>().velocity.z));

        // Get keyboard input
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity -= arrowMove;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += arrowMove;
        }

        GetComponent<Rigidbody>().velocity = new Vector3(Math.Min(velocity.x * 0.95F, maxSidewaysSpeed), velocity.y, zSpeed);
    }
}
