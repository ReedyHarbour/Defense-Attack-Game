using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public GameObject curr;

    Vector2 startPos;
    Transform parent;
    bool dragged = false;
    int index;
    void Update()
    {
        if (dragged) return;
    }

    public void OnBeginDrag(PointerEventData data)
    {
        if (!dragged)
        {
            curr = gameObject;
            startPos = transform.position;
            parent = transform.parent.parent;
            index = int.Parse(transform.parent.tag[3].ToString());
        }
    }

    public void OnDrag(PointerEventData data)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (transform.parent.parent == parent)
        {
            transform.position = startPos;
            // GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            transform.position = transform.parent.position;
            Board.numOfCards--;
            Board.has_card[index-1] = false;
            int coins = curr.GetComponent<Brick>().coins;
            Board.coins -= coins;
            dragged = true;
        }
        curr = null;

    }
    
}
