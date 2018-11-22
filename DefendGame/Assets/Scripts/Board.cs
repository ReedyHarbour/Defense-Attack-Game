using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
    public GameObject[] generator = new GameObject[6];
    public static string FAU = "2FA";
    public static string ATV = "ATV SFTW";
    public static string FRW = "FRWL";
    public static string PWM = "PSW MNG";
    public static string BRS = "BRS PLGN";
    public static string PSW = "STRN PSW";
    public string[] brickList = new string[] { FAU, ATV, FRW, PWM, BRS, PSW };
    public int[] scoreList = new int[] { 1, 2, 3, 3, 2, 1 };
    public int[] lifeList = new int[] { 2, 3, 4, 3, 2, 1 };
    // colorList = [DEEPSKY, DARKORANGE, DARKORANGE, DEEPSKY, PINK, DEEPSKY]
    public int[] protectRadius = new int[] { 2, 2, 2, 3, 3, 1 };
    public int[] coolDownTime = new int[] { 2, 2, 2, 3, 3, 1 };
    // boardColorList = [DARKORANGE, DEEPSKY, DEEPSKY, DARKORANGE, DEEPSKY, DEEPSKY, PINK]
    // Use this for initialization
    public static ArrayList cells;
    public static ArrayList bricks;

    bool flag = false;
    int number = 0;

    void Start () {
        // initiate board information
        cells = new ArrayList();
        bricks = new ArrayList();
        StartCoroutine(Repeat());
    }
	
	// Update is called once per frame
	void Update () {
    
    }

    IEnumerator Repeat() {
        while (true) {
            int newNum = Random.Range(0, 6);
            yield return new WaitForSeconds(2f);
            generator[newNum].GetComponent<Generate>().generateVirus();
            //GameObject.Instantiate(clone, pos, Quaternion.identity);
            number++;
        }

    }

}
