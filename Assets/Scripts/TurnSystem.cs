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

    public GameObject Battlefield;
    public GameObject playerDeck;
    public GameObject CombatSystem;


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
        CombatSystem.GetComponent<Combat>().CommenceCombat(Battlefield.GetComponent<Battlefield>().playerBattlefieldZones, Battlefield.GetComponent<Battlefield>().opponentBattlefieldZones);

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
