using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoardMovement : MonoBehaviour
{
    // Speed limits
    public float maxSpeed;
    public float maxSidewaysSpeed;

    // Movement when player holds an arrow key
    public Vector3 arrowMove;

    // The width of the track, so that the player never falls off
    public GameObject track;

    private float minX, centerX, maxX;
    private float trackWidth;

    // Use this for initialization
    void Start()
    {
        minX = track.GetComponent<Collider>().bounds.min.x + GetComponent<Collider>().bounds.size.x;
        centerX = track.GetComponent<Collider>().bounds.center.x;
        maxX = track.GetComponent<Collider>().bounds.max.x - GetComponent<Collider>().bounds.size.x;
        trackWidth = minX - centerX;
    }

    // Update is called once per frame
    void Update()
    {
        // Set the maximum velocity
        Vector3 velocity = GetComponent<Rigidbody>().velocity;

        // Make sure the board is moving forward at the maximum speed at max
        float zSpeed = velocity.z + 1.0F;
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

        // Make sure the board doesn't fall off the track :)
        if (GetComponent<Collider>().bounds.min.x < minX)
        {
            moveSideways(track.GetComponent<Collider>().bounds.min.x, GetComponent<Collider>().bounds.min.x, ref velocity.x, 1.0F);
        }
        if (GetComponent<Collider>().bounds.max.x > maxX)
        {
            moveSideways(track.GetComponent<Collider>().bounds.max.x, GetComponent<Collider>().bounds.max.x, ref velocity.x, -1.0F);
        }

        GetComponent<Rigidbody>().velocity = new Vector3(Math.Min(velocity.x * 0.95F, maxSidewaysSpeed), velocity.y, zSpeed);
    }

    void moveSideways(float trackMaxX, float boardMaxX, ref float xVel, float directionSign)
    {
        float distFromEdge = Math.Abs(trackMaxX - boardMaxX);
        xVel += directionSign * arrowMove.x * (1.0F - (float)Math.Cos(Math.PI / distFromEdge / 2));
    }
}
