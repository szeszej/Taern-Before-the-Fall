using UnityEngine;

public class Battlefield : MonoBehaviour
{
    public Card[] cardsOnBattlefield;
    public Card[] opponentCardsOnBattlefield;

    public GameObject[] playerBattlefieldZones;
    public GameObject[] opponentBattlefieldZones;

    private GameObject NewCard;
    public GameObject NewCardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        cardsOnBattlefield = new Card[5];
        opponentCardsOnBattlefield = new Card[5];

        for (int i = 0; i < opponentBattlefieldZones.Length; i++)
        {
            opponentCardsOnBattlefield[i] = CardDatabase.cardList[Random.Range(0, 5)].Clone();
            NewCard = Instantiate(NewCardPrefab, transform.position, transform.rotation);
            NewCard.GetComponent<DisplayCard>().displayCard = opponentCardsOnBattlefield[i];
            NewCard.transform.SetParent(opponentBattlefieldZones[i].transform);
            NewCard.transform.localScale = Vector3.one;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
