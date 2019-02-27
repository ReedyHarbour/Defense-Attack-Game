using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {
    public GameObject board;
    private void Start()
    {
        board = GameObject.Find("Canvas");
    }
    public void generateCard()
    {
        int num = Random.Range(0, 15);
        Transform card = Instantiate(board.GetComponent<Board>().cards[num], GetComponent<RectTransform>().anchoredPosition, Quaternion.identity);
        card.transform.SetParent(transform.parent, false);
    }
}
