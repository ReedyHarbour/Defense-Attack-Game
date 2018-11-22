using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    // Use this for initialization
    public Board board;
    public int type;
    public string name;
    public int life;
    public int defaultLife;
    public int score;
    public int radius;
    public int coolDown;
    void Start () {
        //life = board.lifeList[type];
        //defaultLife = board.lifeList[type];
        //score = board.scoreList[type];
        //radius = board.protectRadius[type];
        //coolDown = board.coolDownTime[type];

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        
    }
}
