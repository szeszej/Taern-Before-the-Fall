using UnityEngine;
using Mirror;

public class PlayerHand : NetworkBehaviour
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
        NewCard.GetComponent<DisplayCard>().displayCard.cardObject = NewCard.gameObject;
        NewCard.transform.SetParent(Hand.transform);
        NewCard.transform.localScale = Vector3.one;
        NewCard.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        NewCard.transform.eulerAngles = new Vector3(25, 0, 0);
    }

    private void OnDisable()
    {
        PlayerDeck.cardWasDrawn -= PopulateHand;
    }
}
