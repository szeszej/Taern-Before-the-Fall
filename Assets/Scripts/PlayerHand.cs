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
        int childs = transform.childCount;
        for (int i = 0; i <childs; i++)
        {
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < handList.Count; i++)
        {
            NewCard = Instantiate(CardInHand, transform.position, transform.rotation);
            NewCard.GetComponent<DisplayCard>().displayID = handList[i].id;
        }

    }

    private void OnDisable()
    {
        PlayerDeck.cardWasDrawn -= PopulateHand;
    }
}
