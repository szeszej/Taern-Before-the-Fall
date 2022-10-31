using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Opponent : MonoBehaviour
{

    public int deckSize;
    public int handSize;
    public int hp;
    public int maxMana;
    public int currentMana;
    public List<Card> cardsInDiscard;

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

    public GameObject Hand;

    public Image Health;
    public TextMeshProUGUI hpText;

    public GameObject CardBack;
    public GameObject NewCard;

    public TextMeshProUGUI manaText;

    void Start()
    {

        deckSize = 26;
        handSize = 4;
        hp = 30;
        currentMana = 1;
        maxMana = 1;
        for (int i = 0; i < 4; i++)
        {
            NewCard = Instantiate(CardBack, transform.position, transform.rotation);
            NewCard.transform.SetParent(Hand.transform);
            NewCard.transform.localScale = Vector3.one;
            NewCard.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            NewCard.transform.Rotate(new Vector3(180, 0));

        }

        hpText.text = hp.ToString();
        manaText.text = currentMana.ToString() + "/" + maxMana.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        switch (deckSize)
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
        hpText.text = hp.ToString();
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }
}
