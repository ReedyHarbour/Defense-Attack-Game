using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Board : MonoBehaviour {
    public GameObject[] card_generator = new GameObject[6];
    public static bool[] has_card = new bool[6];
    public int[][] card_coolDown = new int[4][];
    

    public Transform[] cards = new Transform[6];

    public GameObject[] virus_generator = new GameObject[6];

    public static int numOfCards;

    public static int coins = 20;
    public static int score = 0;

    public bool gameOver = false;
    public GUIText text;
    public GameObject panel;
    enum Card_Type
    {
        Account = 0,
        Action = 1,
        Browser = 2,
        Local = 3
    }

    enum Virus_Type
    {
        regu = 0,
        strong = 1,
        hidden = 2
    }


    void Start () {
        numOfCards = 6;
        for (int i = 0; i < has_card.Length; i++) {
            has_card[i] = true;
        }

        card_coolDown[0] = new int[4];
        card_coolDown[1] = new int[5];
        card_coolDown[2] = new int[4];
        card_coolDown[3] = new int[2];

        StartCoroutine(Repeat());
        StartCoroutine(UpdateCards());
    }
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            text.gameObject.SetActive(true);
        }
        else
        {
            //Transform[] c = panel.GetComponentsInChildren<Transform>();
            //numOfCards = c.Length;
        }
    }

    int getIndex()
    {
        int i = Random.Range(0, 6);
        while (has_card[i])
        {
            // randomly choose an empty position
            i = Random.Range(0, 6);
        }
        return i;
    }

    IEnumerator UpdateCards()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (numOfCards < 6)
            {
                int i = getIndex();
                card_generator[i].GetComponent<Generate>().generateCard();
                has_card[i] = true;
                numOfCards++;
            }
        }

    }

    IEnumerator Repeat() {
        while (!gameOver) {
            int virus_pos = Random.Range(0, 6);
            int t = Random.Range(0, 10); // virus type
            yield return new WaitForSeconds(4f);
            int index;
            if (t < 6) {
                index = 0;
            }
            else if (t < 8) {
                index = 1;
            }
            else {
                index = 2;
            }
            virus_generator[virus_pos].GetComponent<VirusPos>().generateVirus(index);
        }

    }

}
