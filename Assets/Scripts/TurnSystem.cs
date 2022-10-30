using TMPro;
using UnityEngine;
using Mirror;

public class TurnSystem : NetworkBehaviour
{

    public bool isSetupPhase;
    public int turn;
    public TextMeshProUGUI phaseText;
    public TextMeshProUGUI turnText;

    public int maxMana;
    public int currentMana;
    public TextMeshProUGUI manaText;

    public GameObject Battlefield;
    public PlayerDeck PlayerDeck;
    public GameObject CombatSystem;


    public override void OnStartClient()
    {
        base.OnStartClient();
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerDeck = networkIdentity.GetComponent<PlayerDeck>();

    }

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
        EndCombatPhase();
    }

    public void EndCombatPhase()
    {
        isSetupPhase = true;
        turn += 1;
        maxMana += 1;
        currentMana = maxMana;
        turnText.text = "Turn: " + turn.ToString();
        PlayerDeck.GetComponent<PlayerDeck>().CmdDraw(1);
    }

    public void Set12Mana()
    {
        currentMana = 12;
    }
}
