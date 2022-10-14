using UnityEngine;

public class PlayerHand : MonoBehaviour
{


    public GameObject Hand;
    public GameObject CardInHand;

    private void OnEnable()
    {
        PlayerDeck.cardWasDrawn += PopulateHand;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void PopulateHand(Card card)
    {

        GameObject NewCard = Instantiate(CardInHand, transform.position, transform.rotation);
        NewCard.GetComponent<DisplayCard>().displayCard = card;

    }

    private void OnDisable()
    {
        PlayerDeck.cardWasDrawn -= PopulateHand;
    }
}
