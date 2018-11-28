using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    // Use this for initialization
    public int type;
    public string name;
    public int life;
    public int defaultLife;
    public int coins;
    void Start () {
        defaultLife = life;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "virus")
        {
            life--;
        }
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

}
