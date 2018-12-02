using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public GameObject curr;
    Vector3 startPos;
    Transform oldparent;
    bool dragged = false;
    public bool indrag = false;
    int index;
    void Update()
    {
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
            transform.position = Input.mousePosition;
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
        if (dragged) return;
        if (!canPlacePos(transform.parent.tag))
        {
            transform.position = startPos;
            transform.SetParent(oldparent);
        }
        else
        {
            if (canPlacePos(transform.parent.tag))
            {
                transform.position = transform.parent.position;
                Board.numOfCards--;
                Board.has_card[index - 1] = false;
                int coins = curr.GetComponent<Brick>().coins;
                Board.coins -= coins;
                dragged = true;
            }
            curr = null;
        }


    }
    
}
