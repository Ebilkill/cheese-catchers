using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatBar : MonoBehaviour {

    // How filled the heat bar is, [0, 1]
    public float heatBarFill;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<RectTransform>().sizeDelta = new Vector2(heatBarFill * 1050 - 525, GetComponent<RectTransform>().sizeDelta.y);
        heatBarFill -= 0.0025F;
	}

    public void replenishHeatBar()
    {
        heatBarFill = Math.Min(1.0F, heatBarFill + 0.1F);
        Debug.Log("Replenishing");
    }
}
