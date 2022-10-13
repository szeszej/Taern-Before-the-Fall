using TMPro;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{

    public bool isSetupPhase;
    public int turn;
    public TextMeshProUGUI phaseText;
    public TextMeshProUGUI turnText;

    public int maxMana;
    public int currentMana;
    public TextMeshProUGUI manaText;

    public GameObject playerDeck;


    // Start is called before the first frame update
    void Start()
    {
        isSetupPhase = true;
        turn = 1;

        maxMana = 1;
        currentMana = 1;

        turnText.text = "Turn: " + turn.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (isSetupPhase)
        {
            phaseText.text = "Setup Phase";
        }
        else
        {
            phaseText.text = "Combat Phase";
        }
        manaText.text = currentMana.ToString() + "/" + maxMana.ToString();
    }

    public void EndSetupPhase()
    {
        isSetupPhase = false;
        //run combat here

    }

    public void EndCombatPhase()
    {
        isSetupPhase = true;
        turn += 1;
        maxMana += 1;
        currentMana = maxMana;
        turnText.text = "Turn: " + turn.ToString();
        playerDeck.GetComponent<PlayerDeck>().Draw(1);
    }

    public void Set12Mana()
    {
        currentMana = 12;
    }
}
