using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerDeck : MonoBehaviour
{

    public List<Card> deck = new();
 

    void Start()
    {
        int x;

        for (int i = 0; i < 30; i++)
        {
            x = Random.Range(0, 5);
            deck.Add(CardDatabase.cardList[x]);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
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
