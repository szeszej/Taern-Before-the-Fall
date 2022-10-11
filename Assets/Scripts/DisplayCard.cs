using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCard : MonoBehaviour
{

    public Card displayCard;

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

        

    }

    // Update is called once per frame
    void Update()
    {

        id = displayCard.id;
        cardName = displayCard.cardName;
        image = displayCard.image;
        description = displayCard.description;
        attack = displayCard.attack;
        hp = displayCard.hp;
        cost = displayCard.cost;
        speed = displayCard.speed;
        spriteImage = displayCard.spriteImage;

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
