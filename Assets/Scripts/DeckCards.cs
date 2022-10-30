using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DeckCards : NetworkBehaviour
{

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;
    public GameObject cardInDeck5;
    public GameObject cardInDeck6;
    public GameObject cardInDeck7;
    public GameObject cardInDeck8;
    public GameObject cardInDeck9;
    public GameObject cardInDeck10;

    PlayerDeck PlayerDeck;

    private void OnEnable()
    {
        PlayerDeck.cardWasDrawn += ChangeDeckSize;
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerDeck = networkIdentity.GetComponent<PlayerDeck>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void ChangeDeckSize(Card card)
    {
        switch (PlayerDeck.deck.Count)
        {
            case < 30 when cardInDeck1.activeSelf:
                cardInDeck1.SetActive(false);
                break;
            case < 20 when cardInDeck2.activeSelf:
                cardInDeck2.SetActive(false);
                break;
            case < 15 when cardInDeck3.activeSelf:
                cardInDeck3.SetActive(false);
                break;
            case < 10 when cardInDeck4.activeSelf:
                cardInDeck4.SetActive(false);
                break;
            case < 8 when cardInDeck5.activeSelf:
                cardInDeck5.SetActive(false);
                break;
            case < 5 when cardInDeck6.activeSelf:
                cardInDeck6.SetActive(false);
                break;
            case < 4 when cardInDeck7.activeSelf:
                cardInDeck7.SetActive(false);
                break;
            case < 3 when cardInDeck8.activeSelf:
                cardInDeck8.SetActive(false);
                break;
            case < 2 when cardInDeck9.activeSelf:
                cardInDeck9.SetActive(false);
                break;
            case < 1 when cardInDeck10.activeSelf:
                cardInDeck10.SetActive(false);
                break;
        }
    }

    private void OnDisable()
    {
        PlayerDeck.cardWasDrawn -= ChangeDeckSize;
    }
}
