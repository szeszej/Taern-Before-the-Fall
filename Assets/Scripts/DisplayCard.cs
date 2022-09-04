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

    public bool FaceDown;
    public static bool staticCardBack;


    // Start is called before the first frame update
    void Start()
    {
        displayCard[0] = CardDatabase.cardList[displayID];

        id = displayCard[0].id;
        cardName = displayCard[0].cardName;
        image = displayCard[0].image;
        description = displayCard[0].description;
        attack = displayCard[0].attack;
        hp = displayCard[0].hp;
        cost = displayCard[0].cost;
        speed = displayCard[0].speed;
        spriteImage = displayCard[0].spriteImage;

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

    // Update is called once per frame
    void Update()
    {

        staticCardBack = FaceDown;

    }
}
