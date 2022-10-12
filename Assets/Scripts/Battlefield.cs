using UnityEngine;

public class Battlefield : MonoBehaviour
{
    public Card[] cardsOnBattlefield;
    public Card[] opponentCardsOnBattlefield;

    // Start is called before the first frame update
    void Start()
    {
        cardsOnBattlefield = new Card[3];
        opponentCardsOnBattlefield = new Card[3];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
