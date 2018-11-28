using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScore : MonoBehaviour {
	// Use this for initialization
	void Start () {
        GetComponent<UnityEngine.UI.Text>().text = "Score: ";
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<UnityEngine.UI.Text>().text = "Score: " + Board.score.ToString();
    }
}
