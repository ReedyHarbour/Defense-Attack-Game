using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCoins : MonoBehaviour {
    public GameObject board;
    // Use this for initialization
    void Start()
    {
        GetComponent<UnityEngine.UI.Text>().text = "Coins: ";
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = "Coins: " + board.GetComponent<Board>().coins.ToString();
    }
}
