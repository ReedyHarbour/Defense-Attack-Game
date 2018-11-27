using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScore : MonoBehaviour {
    public GameObject board;
	// Use this for initialization
	void Start () {
        GetComponent<UnityEngine.UI.Text>().text = "Score: ";
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<UnityEngine.UI.Text>().text = "Score: " + board.GetComponent<Board>().score.ToString();
    }
}
