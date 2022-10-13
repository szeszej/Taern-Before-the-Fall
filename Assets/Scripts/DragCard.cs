using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform parentToRetunTo;
    private int originalIndex;

    public delegate void CardIsDragged(bool shouldBlock);
    public static event CardIsDragged cardIsDragged;

    public delegate void CardIsNotDragged(bool shouldBlock);
    public static event CardIsDragged cardIsNotDragged;

    public GameObject Mana;

    // Start is called before the first frame update
    void Start()
    {
        Mana = GameObject.Find("TurnSystem");
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
        cardIsDragged(false);

    }

    public void OnDrag(PointerEventData eventData)
    {

        this.transform.position = eventData.pointerCurrentRaycast.worldPosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
  
        if (eventData.pointerEnter.tag == "DropSlot" && checkMana(gameObject.GetComponent<DisplayCard>().displayCard.cost))
        {
            Mana.GetComponent<TurnSystem>().currentMana -= gameObject.GetComponent<DisplayCard>().displayCard.cost;
            eventData.pointerEnter.GetComponent<CardDropZone>().PlayCard(gameObject);
        } else
        {
            //if not a drop zone, let's return whence we came
            this.transform.SetParent(parentToRetunTo);
            this.transform.SetSiblingIndex(originalIndex);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        cardIsNotDragged(true);

    }

    bool checkMana(int cost)
    {
        if (cost <= Mana.GetComponent<TurnSystem>().currentMana)
        {
            return true;
        } else
        {
            return false;
        }
        
    }

}
