using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerDeck : NetworkBehaviour
{

    public List<Card> deck = new();

    private GameObject cardInDeck1;
    private GameObject cardInDeck2;
    private GameObject cardInDeck3;
    private GameObject cardInDeck4;
    private GameObject cardInDeck5;
    private GameObject cardInDeck6;
    private GameObject cardInDeck7;
    private GameObject cardInDeck8;
    private GameObject cardInDeck9;
    private GameObject cardInDeck10;

    public delegate void CardDrawn(Card card);
    public static event CardDrawn cardWasDrawn;


    public override void OnStartClient()
    {
        base.OnStartClient();

        cardInDeck1 = GameObject.Find("CardBack");
        cardInDeck2 = GameObject.Find("CardBack (1)");
        cardInDeck3 = GameObject.Find("CardBack (2)");
        cardInDeck4 = GameObject.Find("CardBack (3)");
        cardInDeck5 = GameObject.Find("CardBack (4)");
        cardInDeck6 = GameObject.Find("CardBack (5)");
        cardInDeck7 = GameObject.Find("CardBack (6)");
        cardInDeck8 = GameObject.Find("CardBack (7)");
        cardInDeck9 = GameObject.Find("CardBack (8)");
        cardInDeck10 = GameObject.Find("CardBack (9)");

    }

    [Server]
    public override void OnStartServer()
    {
        base.OnStartServer();
        for (int i = 0; i < 30; i++)
        {
            deck.Add(CardDatabase.cardList[Random.Range(0, 5)].Clone());
        }
        StartGame();

    }

    // Update is called once per frame
    void Update()
    {
        switch (deck.Count)
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

    public void StartGame()
    {
        StartCoroutine(DelayedDraw(4));
    }

    public IEnumerator DelayedDraw(int number)
    {
        for (int i = 0; i < number; i++)
        {

            yield return new WaitForSeconds(1);
            CmdDraw(1);
        }

    }

    [Command]
    public void CmdDraw(int number)
    {
        for (int i = 0; i < number; i++)
        {
            if (cardWasDrawn != null) cardWasDrawn(deck[0]);
            deck.RemoveAt(0);
        }
    }

    public void Shuffle()
    {
        int currentIndex = deck.Count;
        Card temporaryValue;
        int randomIndex;

        // While there remain elements to shuffle...
        while (0 != currentIndex)
        {
            // Pick a remaining element...
            randomIndex = Random.Range(0, currentIndex);
            currentIndex -= 1;

            // And swap it with the current element.
            temporaryValue = this.deck[currentIndex];
            this.deck[currentIndex] = this.deck[randomIndex];
            this.deck[randomIndex] = temporaryValue;
        }

    }
}
