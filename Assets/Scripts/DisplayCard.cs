using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCard : MonoBehaviour
{

    public Card displayCard;

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

        nameText.text = displayCard.cardName;
        if (descriptionText) descriptionText.text = displayCard.description;
        attackText.text = displayCard.attack.ToString();
        hpText.text = displayCard.hp.ToString();
        costText.text = displayCard.cost.ToString();
        cardImage.sprite = displayCard.spriteImage;

        switch (displayCard.speed)
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




    }
}
