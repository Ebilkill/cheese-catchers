using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHeatwaves : MonoBehaviour {

    GameObject heatwave;
    GameObject player;
    // Use this for initialization
    void Start () {
        heatwave = (GameObject)Resources.Load("HeatWave");
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateHW() {
        float RandValue = Random.value;
        float PosZ = player.transform.position.z;
        //float posX = Random.RandomRange();
        if(RandValue >= 0 && RandValue <= 0.3) {
           // Instantiate(heatwave, player.transform.position.) )
        }
    }
}
