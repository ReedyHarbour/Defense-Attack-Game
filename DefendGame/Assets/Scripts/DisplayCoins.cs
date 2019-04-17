using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCoins : MonoBehaviour {
    // Use this for initialization
    void Start()
    {
        GetComponent<UnityEngine.UI.Text>().text = "30";
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = Board.coins.ToString();
    }
}
