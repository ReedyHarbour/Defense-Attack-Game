using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
    public string FAU = "2FA";
    public string ATV = "ATV SFTW";
    public string FRW = "FRWL";
    public string PWM = "PSW MNG";
    public string BRS = "BRS PLGN";
    public string PSW = "STRN PSW";
    public string[] brickList = new string[] { FAU, ATV, FRW, PWM, BRS, PSW };
    public int[] scoreList = new int[] { 1, 2, 3, 3, 2, 1 };
    public int[] lifeList = new int[] { 2, 3, 4, 3, 2, 1 };
    // colorList = [DEEPSKY, DARKORANGE, DARKORANGE, DEEPSKY, PINK, DEEPSKY]
    public int[] protectRadius = new int[] { 2, 2, 2, 3, 3, 1 };
    public int[] coolDownTime = new int[] { 2, 2, 2, 3, 3, 1 };
    // boardColorList = [DARKORANGE, DEEPSKY, DEEPSKY, DARKORANGE, DEEPSKY, DEEPSKY, PINK]
    // Use this for initialization
    ArrayList cells;
    ArrayList bricks;
    void Start () {
        // initiate board information
        cells = new ArrayList();
        bricks = new ArrayList();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void addCell(int speed, int position) {
        Cell cell = new Cell(speed, position);
        if (!this.cells.Contains(cell)) {
            this.cells.Add(cell);
        }
    }
}
