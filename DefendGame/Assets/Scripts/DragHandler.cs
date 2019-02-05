using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public GameObject curr;
    Vector3 startPos;
    Transform oldparent;
    public GameObject[] positions = new GameObject[7];
    public bool dragged = false;
    public bool indrag = false;
    int index;

    public AudioClip dragSound;
    private AudioSource source;

    private static int CompareList(GameObject i1, GameObject i2)
    {
        return System.String.Compare(i1.name, i2.name);
    }

    void Start()
    {
        positions = GameObject.FindGameObjectsWithTag("Row");
        System.Array.Sort(positions, CompareList);
        // dragSound = GameObject.Find("drag");
        source = GetComponent<AudioSource>();
        // source.PlayOneShot(dragSound.GetComponent<AudioClip>(), 0.8f);
    }


    public void OnBeginDrag(PointerEventData data)
    {
        if (Board.gameOver) return;
        indrag = true;
        if (!dragged)
        {
            curr = gameObject;
            startPos = transform.position;
            
            oldparent = transform.parent;
            index = int.Parse(transform.parent.tag[3].ToString());
        }
    }

    public void OnDrag(PointerEventData data)
    {
        if (Board.gameOver) return;
        indrag = true;
        if (!dragged)
        {
            highlightPos(true);
            transform.position = Input.mousePosition;
        }
    }

    public void highlightPos(bool change)
    {
        bool[] L = GetComponent<Brick>().canPlace;
        for (int i = 0; i < 7; i++)
        {
            if (L[i])
            {
                // positions[i].SetActive(change);
                Color c = positions[i].GetComponent<Image>().color;
                if (change) c.a = 0.5f;
                else c.a = 0;
                positions[i].GetComponent<Image>().color = c;
            }
        }

    }

    public bool canPlacePos(string tag)
    {
        if (!tag.StartsWith("Row")) return false;
        int index = int.Parse(transform.parent.tag[3].ToString());
        if (GetComponent<Brick>().canPlace[index-1])
        {
            return true;
        }
        return false;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (Board.gameOver) return;
        indrag = false;
        // if (dragged) return;
        highlightPos(false);
        if (transform.tag != "Card" || !canPlacePos(transform.parent.tag))
        {
            transform.position = startPos;
            transform.SetParent(oldparent);
            source.PlayOneShot(dragSound, 0.8f);
        }
        else
        {
            //if (canPlacePos(transform.parent.tag))
            //{
                transform.position = transform.parent.position;
                Board.numOfCards--;
                Board.has_card[index - 1] = false;
                int coins = curr.GetComponent<Brick>().coins;
                Board.coins -= coins;
                dragged = true;
            //}
            curr = null;
        }
        
    }
    
}
