using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour {
    public float startTime;
	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - startTime < 10)
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        else GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
