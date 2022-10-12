using UnityEngine;
using UnityEngine.EventSystems;

public class CardDropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject Battlefield;
    public GameObject DiscardPile;

    private GameObject CardOnBattlefield;
    private GameObject CardToDiscard;

    public GameObject CardOnBattlefieldPrefab;
    public GameObject CardInDiscardPrefab;


    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnDrop(PointerEventData eventData)
    {
        //if there's already a card in the slot, it has to be discarded
        if (this.transform.childCount > 0)
        {
            CardToDiscard = Instantiate(CardInDiscardPrefab, transform.position, transform.rotation);
            CardToDiscard.GetComponent<DisplayCard>().displayCard = CardDatabase.cardList[CardOnBattlefield.GetComponent<DisplayCard>().displayCard.id].Clone();
            Destroy(CardOnBattlefield.gameObject);
            CardToDiscard.transform.SetParent(DiscardPile.transform);
            CardToDiscard.transform.localScale = Vector3.one;
            DiscardPile.GetComponent<DiscardPile>().cardsInDiscard.Add(CardToDiscard.GetComponent<DisplayCard>().displayCard);
        }
        //in any case, a new look needs to be applied to the card so that it fits
        CardOnBattlefield = Instantiate(CardOnBattlefieldPrefab, transform.position, transform.rotation);
        CardOnBattlefield.GetComponent<DisplayCard>().displayCard = eventData.pointerDrag.GetComponent<DisplayCard>().displayCard;
        //CardOnBattlefield.GetComponent<CanvasGroup>().blocksRaycasts = false;
        CardOnBattlefield.transform.SetParent(gameObject.transform);
        CardOnBattlefield.transform.localScale = Vector3.one;
        Destroy(eventData.pointerDrag.gameObject);

        //the card needs to be added to the battlefield for combat purposes
        switch (this.name)
        {
            case "Slot1":
                Battlefield.GetComponent<Battlefield>().cardsOnBattlefield[0] = eventData.pointerDrag.GetComponent<DisplayCard>().displayCard;
                break;
            case "Slot2":
                Battlefield.GetComponent<Battlefield>().cardsOnBattlefield[1] = eventData.pointerDrag.GetComponent<DisplayCard>().displayCard;
                break;
            case "Slot3":
                Battlefield.GetComponent<Battlefield>().cardsOnBattlefield[2] = eventData.pointerDrag.GetComponent<DisplayCard>().displayCard;
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
