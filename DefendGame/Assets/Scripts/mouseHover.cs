using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseHover : MonoBehaviour {

    public int index;
    public Canvas canvas;
    GameObject Description;
    private void Start()
    {
        // canvas = GetComponentInParent<Canvas>();
        Description = canvas.GetComponent<Board>().descriptions[index];
    }
    void OnMouseOver()
    {
        Description.SetActive(true);
    }
    private void OnMouseExit()
    {
        Description.SetActive(false);
    }
}
