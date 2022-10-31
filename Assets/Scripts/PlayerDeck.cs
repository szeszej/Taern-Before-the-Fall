using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerDeck : NetworkBehaviour
{

    public List<Card> deck = new();

    public delegate void CardDrawn(Card card);
    public static event CardDrawn cardWasDrawn;


    [Server]
    public override void OnStartServer()
    {
        base.OnStartServer();

    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        for (int i = 0; i < 30; i++)
        {
            deck.Add(CardDatabase.cardList[Random.Range(0, 5)].Clone());
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
            Draw(1);
        }

    }

    public void Draw(int number)
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
