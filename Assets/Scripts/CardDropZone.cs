using UnityEngine;
using UnityEngine.EventSystems;

public class CardDropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject Battlefield;
    public GameObject DiscardPile;

    private GameObject CardOnBattlefield;

    public GameObject CardOnBattlefieldPrefab;
    public GameObject CardInDiscardPrefab;

    public delegate void CardPlayed();
    public static event CardPlayed cardWasPlayed;


    private void OnEnable()
    {
        DragCard.cardIsDragged += blockRaycasts;
        DragCard.cardIsNotDragged += blockRaycasts;
    }

    private void blockRaycasts(bool shouldBlock)
    {
        if (CardOnBattlefield) CardOnBattlefield.GetComponent<CanvasGroup>().blocksRaycasts = shouldBlock;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void PlayCard(GameObject PlayedCard)
    {

        //if there's already a card in the slot, it has to be discarded
        if (this.transform.childCount > 0)
        {
            GameObject CardToDiscard = Instantiate(CardInDiscardPrefab, transform.position, transform.rotation);
            CardToDiscard.GetComponent<DisplayCard>().displayCard = CardDatabase.cardList[CardOnBattlefield.GetComponent<DisplayCard>().displayCard.id].Clone();
            Destroy(CardOnBattlefield.gameObject);
            CardToDiscard.transform.SetParent(DiscardPile.transform);
            CardToDiscard.transform.localScale = Vector3.one;
            DiscardPile.GetComponent<DiscardPile>().cardsInDiscard.Add(CardToDiscard.GetComponent<DisplayCard>().displayCard);
        }
        //in any case, a new look needs to be applied to the card so that it fits
        CardOnBattlefield = Instantiate(CardOnBattlefieldPrefab, transform.position, transform.rotation);
        CardOnBattlefield.GetComponent<DisplayCard>().displayCard = PlayedCard.GetComponent<DisplayCard>().displayCard;
        CardOnBattlefield.transform.SetParent(gameObject.transform);
        CardOnBattlefield.transform.localScale = Vector3.one;
        Destroy(PlayedCard.gameObject);

        //the card needs to be added to the battlefield for combat purposes
        switch (this.name)
        {
            case "Slot1":
                Battlefield.GetComponent<Battlefield>().cardsOnBattlefield[0] = PlayedCard.GetComponent<DisplayCard>().displayCard;
                break;
            case "Slot2":
                Battlefield.GetComponent<Battlefield>().cardsOnBattlefield[1] = PlayedCard.GetComponent<DisplayCard>().displayCard;
                break;
            case "Slot3":
                Battlefield.GetComponent<Battlefield>().cardsOnBattlefield[2] = PlayedCard.GetComponent<DisplayCard>().displayCard;
                break;
            case "Slot4":
                Battlefield.GetComponent<Battlefield>().cardsOnBattlefield[3] = PlayedCard.GetComponent<DisplayCard>().displayCard;
                break;
            case "Slot5":
                Battlefield.GetComponent<Battlefield>().cardsOnBattlefield[4] = PlayedCard.GetComponent<DisplayCard>().displayCard;
                break;
        }

        if (cardWasPlayed != null) cardWasPlayed();
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

    public void OnDrop(PointerEventData eventData)
    {

    }

    private void OnDisable()
    {
        DragCard.cardIsDragged -= blockRaycasts;
        DragCard.cardIsNotDragged -= blockRaycasts;
    }


}
