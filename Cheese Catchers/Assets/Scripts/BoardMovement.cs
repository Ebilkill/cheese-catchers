﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BoardMovement : MonoBehaviour
{
    // Speed limits
    public float maxSpeed = 10;
    public float maxSidewaysSpeed = 10;

    // Movement when player holds an arrow key
    public Vector3 arrowMove = new Vector3(0.5F, 0, 0);

    // The width of the track, so that the player never falls off
    public GameObject track;

    // This object's collider
    private Collider collider;

    public float heatSpeedMod = 1.0F;

    private float minX, centerX, maxX;
    private float trackWidth;

    // Use this for initialization
    void Start()
    {
        collider = GetComponent<Collider>();
        minX = track.GetComponent<Collider>().bounds.min.x + collider.bounds.size.x;
        centerX = track.GetComponent<Collider>().bounds.center.x;
        maxX = track.GetComponent<Collider>().bounds.max.x - collider.bounds.size.x;
        trackWidth = minX - centerX;
    }

    // Update is called once per frame
    void Update()
    {

        // Set the maximum velocity
        Vector3 velocity = GetComponent<Rigidbody>().velocity;

        // Make sure the board is moving forward at the maximum speed at max
        float zSpeed = velocity.z + 1.0F;
        zSpeed *= (float)Math.Min(1, heatSpeedMod * maxSpeed / Math.Sqrt(GetComponent<Rigidbody>().velocity.z * GetComponent<Rigidbody>().velocity.z));

        // Ending condition
        if (collider.bounds.max.z > 1111 || zSpeed <= 0)
        {
            // PLAYER HAS WON O_O
            SceneManager.LoadScene("End screen", LoadSceneMode.Single);
        }

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
        if (collider.bounds.min.x < minX)
        {
            moveSideways(track.GetComponent<Collider>().bounds.min.x, collider.bounds.min.x, ref velocity.x, 1.0F);
        }
        if (collider.bounds.max.x > maxX)
        {
            moveSideways(track.GetComponent<Collider>().bounds.max.x, collider.bounds.max.x, ref velocity.x, -1.0F);
        }

        GetComponent<Rigidbody>().velocity = new Vector3(Math.Min(velocity.x * 0.95F, maxSidewaysSpeed), velocity.y, zSpeed);
    }

    void moveSideways(float trackMaxX, float boardMaxX, ref float xVel, float directionSign)
    {
        float distFromEdge = Math.Abs(trackMaxX - boardMaxX);
        xVel += directionSign * arrowMove.x * (1.0F - (float)Math.Cos(Math.PI / distFromEdge / 2));
    }
}
