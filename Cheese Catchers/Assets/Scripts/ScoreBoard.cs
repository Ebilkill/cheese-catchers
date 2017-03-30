using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour {

    private GUIText text;
    private int score;

	// Use this for initialization
	void Start () {
		text = GameObject.Find("GUI_TEXT_NAME").GetComponent<GUIText>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setScore(int score)
    {
        this.score = score;
        text.text = "Score: " + score;
    }
}
