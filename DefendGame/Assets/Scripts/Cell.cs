using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public GameObject board;
    public float speed;
    public int life;
    public int score;
    Board s;

    // Update is called once per frame
    void Update()
    {
        moveLeft();
        if (life <= 0)
        {
            Destroy(gameObject);
            Board.score += score;
        }
    }

    void moveLeft()
    {
        transform.position = new Vector2(transform.position.x-speed, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Card")
        {
            life--;
        }
    }


}
