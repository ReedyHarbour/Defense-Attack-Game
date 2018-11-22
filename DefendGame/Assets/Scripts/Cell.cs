using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    public int speed;
    public int tag;
    public Transform prefab;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        moveLeft();
    }

    void moveLeft()
    {
        transform.position = new Vector2(transform.position.x-speed, transform.position.y);
    }

    public override bool Equals(System.Object obj)
    {
        if (obj == null)
            return false;
        Cell c = obj as Cell;
        if ((System.Object)c == null)
            return false;
        return transform.position == c.transform.position && speed == c.speed && tag == c.tag;
    }

    public bool Equals(Cell c)
    {
        if ((object)c == null)
            return false;
        return transform.position == c.transform.position && speed == c.speed && tag == c.tag;
    }
}
