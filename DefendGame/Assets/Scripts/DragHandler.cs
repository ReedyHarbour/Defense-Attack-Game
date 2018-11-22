using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public static GameObject curr;
    Vector2 startPos;
    Transform parent;

    public void OnBeginDrag(PointerEventData data)
    {
        curr = gameObject;
        startPos = transform.position;
        parent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData data)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData data)
    {
        curr = null;
        if (parent == transform.parent)
        {
            transform.position = startPos;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            transform.position = transform.parent.position;
        
        }
        
    }
}
