using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{

    public List<Card> handList = new();
    public GameObject Hand;
    public GameObject CardInHand;
    public GameObject NewCard;

    private void OnEnable()
    {
        PlayerDeck.cardWasDrawn += PopulateHand;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void PopulateHand()
    {

            NewCard = Instantiate(CardInHand, transform.position, transform.rotation);
            NewCard.GetComponent<DisplayCard>().displayID = handList[handList.Count - 1].id;

    }

    private void OnDisable()
    {
        PlayerDeck.cardWasDrawn -= PopulateHand;
    }
}
