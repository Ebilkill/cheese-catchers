using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHeatwaves : MonoBehaviour {

    public Transform heatwave;
    // Use this for initialization
    void Start() {
        CreateHW();
    }

    // Update is called once per frame
    void Update() {

    }

    void CreateHW() {
        float z = -725f;
        while (z <= 1150f) {
            z = z + 10f + Random.Range(0f, 15f);
            float i = z;

            float RandomZ = Random.Range(0f, 5f) + i;
            float RandomX = Random.Range(-5f, 5f);
            Vector3 pos = new Vector3(RandomX, 0.59f, RandomZ);
            Instantiate(heatwave, pos, Quaternion.identity);
        }
    }
}