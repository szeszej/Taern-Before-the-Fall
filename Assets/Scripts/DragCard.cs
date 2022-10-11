using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform parentToRetunTo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (this.transform.parent.tag != "DropSlot")
        {
            parentToRetunTo = this.transform.parent;
            this.transform.SetParent(GameObject.Find("Canvas").transform);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }            
    }

    public void OnDrag(PointerEventData eventData)
    {

            this.transform.position = eventData.pointerCurrentRaycast.worldPosition;
 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerEnter.tag != "DropSlot")
        {
            this.transform.SetParent(parentToRetunTo);
        } else
        {
            parentToRetunTo = this.transform.parent;
            this.enabled = false;
        }
        
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
