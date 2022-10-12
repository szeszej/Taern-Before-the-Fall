using UnityEngine;
using UnityEngine.EventSystems;

public class DragCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform parentToRetunTo;
    private int originalIndex;

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
        //let's make sure we remember where we came from
        parentToRetunTo = this.transform.parent;
        originalIndex = this.transform.GetSiblingIndex();
        this.transform.SetParent(GameObject.Find("Canvas").transform);
        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {

        this.transform.position = eventData.pointerCurrentRaycast.worldPosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //if not a drop zone, let's return whence we came
        if (eventData.pointerEnter.tag != "DropSlot")
        {
            this.transform.SetParent(parentToRetunTo);
            this.transform.SetSiblingIndex(originalIndex);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

    }
}
