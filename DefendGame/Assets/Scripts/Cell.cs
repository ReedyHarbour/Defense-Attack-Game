using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public GameObject board;
    public float speed;
    public int life;
    public int score;
    public int add_coins;
    Board s;

    // Update is called once per frame
    void Update()
    {
        if (Board.gameOver) return;
        moveLeft();
        
    }

    void moveLeft()
    {
        if (Board.accelerate && !Board.accelerated)
        {
            speed += (float)0.3;
            Board.accelerated = true;
        }
        transform.position = new Vector2(transform.position.x-speed, transform.position.y);
        if (transform.position.x < 300) Board.gameOver = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<DragHandler>().indrag && other.transform.tag == "Card")
        {
            life--;
            if (life <= 0)
            {
                Destroy(gameObject);
                Board.score += score;
                Board.coins += add_coins;
            }
        }
    }


}
