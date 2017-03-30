using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heatwave : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            GameObject go_heatBar = GameObject.Find("HeatBar");
            HeatBar heatBar = (HeatBar)go_heatBar.GetComponent<HeatBar>();
            heatBar.replenishHeatBar();
            Destroy(gameObject);
        }
    }

    
}
