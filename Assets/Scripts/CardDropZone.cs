using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CardDropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject battlefield;

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.transform.SetParent(this.transform);
        switch (this.name)
        {
            case "Slot1":
                battlefield.GetComponent<Battlefield>().cardsOnBattlefield[0] = eventData.pointerDrag.GetComponent<DisplayCard>().displayCard;
                break;
            case "Slot2":
                battlefield.GetComponent<Battlefield>().cardsOnBattlefield[1] = eventData.pointerDrag.GetComponent<DisplayCard>().displayCard;
                break;
            case "Slot3":
                battlefield.GetComponent<Battlefield>().cardsOnBattlefield[2] = eventData.pointerDrag.GetComponent<DisplayCard>().displayCard;
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
