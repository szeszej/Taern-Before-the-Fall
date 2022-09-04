using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerDeck : MonoBehaviour
{
    
    public List<Card> deck = new();

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
