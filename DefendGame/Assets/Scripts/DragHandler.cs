using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public GameObject board;
    public GameObject curr;

    Vector2 startPos;
    Transform parent;

    public void OnBeginDrag(PointerEventData data)
    {
        curr = gameObject;
        startPos = transform.position;
        parent = transform.parent.parent;
        // GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData data)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData data)
    {
        curr = null;
        Debug.Log(transform.parent.parent);
        Debug.Log(parent);
        if (transform.parent.parent == parent)
        {
            transform.position = startPos;
            // GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            transform.position = transform.parent.position;
            board.GetComponent<Board>().numOfCards--;
            int coins = curr.GetComponent<Brick>().defaultLife;
            board.GetComponent<Board>().coins -= coins;
        }
        
    }
    
}
