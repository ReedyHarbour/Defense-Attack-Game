using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
    public GameObject[] card_generator = new GameObject[6];
    public bool[] has_card = new bool[6];
    public int[][] card_coolDown = new int[4][];
    

    public Transform[] cards = new Transform[2];

    public GameObject[] virus_generator = new GameObject[6];

    public int numOfCards = 6;

    public int coins = 20;
    public int score = 0;

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
        while (numOfCards < 6)
        {
            int i = getIndex();
            Debug.Log(i);
            yield return new WaitForSeconds(4f);
            card_generator[i].GetComponent<Generate>().generateCard();
            has_card[i] = true;
            numOfCards++;
        }
    }

    IEnumerator Repeat() {
        while (true) {
            int virus_pos = Random.Range(0, 6);
            int t = Random.Range(0, 10); // virus type
            yield return new WaitForSeconds(2f);
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
