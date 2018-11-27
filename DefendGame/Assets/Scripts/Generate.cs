using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {
    public Transform canvas;

    public void generateCard()
    {
        Transform[] cards = canvas.GetComponent<Board>().cards;
        int num = Random.Range(0, 2);
        Transform card = Instantiate(cards[num], GetComponent<RectTransform>().anchoredPosition, Quaternion.identity);
        card.transform.SetParent(transform.parent, false);
    }
}
