using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayCard : MonoBehaviour
{

    public List<Card> displayCard = new List<Card>();
    public int displayID;

    public int id;
    public string cardName;
    public string image;
    public string description;
    public int attack;
    public int hp;
    public int cost;
    public int speed;
    public Sprite spriteImage;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI costText;
    public Image cardImage;
    public Image speedImage;


    // Start is called before the first frame update
    void Start()
    {
        displayCard[0] = CardDatabase.cardList[displayID];
    }

    // Update is called once per frame
    void Update()
    {
        id = displayCard[0].Id;
        cardName = displayCard[0].CardName;
        image = displayCard[0].Image;
        description = displayCard[0].Description;
        attack = displayCard[0].Attack;
        hp = displayCard[0].Hp;
        cost = displayCard[0].Cost;
        speed = displayCard[0].Speed;
        spriteImage = displayCard[0].SpriteImage;

        nameText.text = " " + cardName;
        descriptionText.text = " " + description;
        attackText.text = " " + attack;
        hpText.text = " " + hp;
        costText.text = " " + cost;
        cardImage.sprite = spriteImage;
        switch (speed)
        {
            case 3:
                speedImage.sprite = Resources.Load<Sprite>("mental");
                break;
            case 2:
                speedImage.sprite = Resources.Load<Sprite>("ranged");
                break;
            default:
                speedImage.sprite = Resources.Load<Sprite>("melee");
                break;
        }
    }
}
