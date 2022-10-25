using UnityEngine;

public class OppCardDropZone : MonoBehaviour
{

    public GameObject Battlefield;
    public GameObject DiscardPile;

    public GameObject CardInDiscardPrefab;

    public void DiscardCard(GameObject discardedCard)
    {
        GameObject CardToDiscard = Instantiate(CardInDiscardPrefab, transform.position, transform.rotation);
        CardToDiscard.GetComponent<DisplayCard>().displayCard = CardDatabase.cardList[discardedCard.GetComponent<DisplayCard>().displayCard.id].Clone();
        Destroy(discardedCard.gameObject);
        CardToDiscard.transform.SetParent(DiscardPile.transform);
        CardToDiscard.transform.localScale = Vector3.one;
        DiscardPile.GetComponent<DiscardPile>().cardsInDiscard.Add(CardToDiscard.GetComponent<DisplayCard>().displayCard);
    }


}
