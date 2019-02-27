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
    public bool accelerated;
    public bool reduced;

    // Board s;
    Animator animator;
    public AudioClip deathSound;
    private AudioSource source;

    void Start()
    {

        animator = GetComponent<Animator>();
        board = GameObject.Find("Canvas");
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Board.gameOver) return;
        if (!HandleText.paused) moveLeft();
        
    }

    void moveLeft()
    {
        if (Board.reduce && !reduced)
        {
            speed = speed + 0.5f;
            reduced = true;
        }
        if (Board.accelerate && !accelerated)
        {
            speed = speed + 0.5f;
            accelerated = true;
            // Debug.Log(speed);
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
                Board.generate_virus = true;
                animator.SetTrigger("Death");
                source.PlayOneShot(deathSound, 0.8f);
                Destroy(gameObject, 2);
                Board.score += score;
                Board.coins += add_coins;
            }
        }
    }


}
