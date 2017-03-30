using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatBar : MonoBehaviour {

    // How filled the heat bar is, [0, 1]
    public float heatBarFill;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(heatBarFill * 1050 - 525, GetComponent<RectTransform>().sizeDelta.y);
	}
}
