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


    void OnEnable()
    {
        CardDropZone.cardWasPlayed += UpdateMana;
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerDeck = networkIdentity.GetComponent<PlayerDeck>();

        manaText = GameObject.Find("ManaText").GetComponent<TextMeshProUGUI>();
        turnText = GameObject.Find("TurnNumber").GetComponent<TextMeshProUGUI>();
        phaseText = GameObject.Find("PhaseText").GetComponent<TextMeshProUGUI>();

        isSetupPhase = true;
        turn = 1;

        maxMana = 1;
        currentMana = 1;

        turnText.text = "Turn: " + turn.ToString();
        manaText.text = currentMana.ToString() + "/" + maxMana.ToString();



    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void UpdateMana()
    {
        manaText.text = currentMana.ToString() + "/" + maxMana.ToString();
    }

    public void EndSetupPhase()
    {
        phaseText.text = "Combat Phase";
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
        PlayerDeck.GetComponent<PlayerDeck>().Draw(1);
        phaseText.text = "Setup Phase";
    }

    public void Set12Mana()
    {
        currentMana = 12;
    }

    private void OnDisable()
    {
        CardDropZone.cardWasPlayed -= UpdateMana;
    }
}
