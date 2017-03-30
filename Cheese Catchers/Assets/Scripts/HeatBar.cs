using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatBar : MonoBehaviour {

    // How filled the heat bar is, [0, 1]
    public float heatBarFill;

    public float speedModBase;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<RectTransform>().sizeDelta = new Vector2(heatBarFill * 1050 - 525, GetComponent<RectTransform>().sizeDelta.y);
        heatBarFill -= 0.0025F;

        // Make sure the player slows down as their heat decreases below 5%
        GameObject go_player = GameObject.FindGameObjectWithTag("Player");
        BoardMovement boardMovement = go_player.GetComponent<BoardMovement>();
        if (heatBarFill < 0.05F)
        {
            boardMovement.heatSpeedMod = Math.Max(heatBarFill / 0.05F, 0);
        }

        // Make sure the player speeds up as their heat increases above 50%
        else if (heatBarFill > 0.50F)
        {
            boardMovement.heatSpeedMod = (float)Math.Pow(speedModBase, heatBarFill + 0.5F) - (speedModBase - 1.0F);
        }

        // Else, make sure that the speed increase/decrease is non-existent
        else
        {
            boardMovement.heatSpeedMod = 1.0F;
        }
        Debug.Log("Speed boost mod: " + boardMovement.heatSpeedMod);

    }

    public void replenishHeatBar()
    {
        heatBarFill = Math.Min(1.0F, heatBarFill + 0.1F);
    }
}
