using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMovement : MonoBehaviour {

    public float maxSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity *= (float)System.Math.Min(1, maxSpeed / System.Math.Sqrt(GetComponent<Rigidbody>().velocity.sqrMagnitude));
	}
}
