using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    // Use this for initialization
    public Board board;
    void Start (int row, int col, int type) {
        Vector2 pos = new Vector2(row, col);
        int brickType = type;
        int life = board.lifeList[type];
        int defaultLife = board.lifeList[type];
        int score = board.scoreList[type];
        int radius = board.protectRadius[type];
        int coolDown = board.coolDownTime[type];

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        
    }
}
