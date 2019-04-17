using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour {

    // Use this for initialization
    public int type;
    public string name;
    public int life;
    public int defaultLife;
    public int coins;

    public bool[] canPlace = new bool[7];
    void Start () {
        defaultLife = life;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!GetComponent<DragHandler>().indrag && other.transform.tag == "virus")
        {
            life--;
            GetComponent<Image>().color = new Color(1,1,1,(float)life/defaultLife);
            Debug.Log(GetComponent<Image>().color);
        }
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

}
