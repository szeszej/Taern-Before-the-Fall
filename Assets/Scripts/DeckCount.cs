using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Mirror;

public class DeckCount : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{


    public PlayerDeck PlayerDeck;
    public GameObject Opponent;
    public GameObject PlayerDeckPanel;
    public GameObject OpponentDeckPanel;
    public GameObject DeckCounter;
    public TextMeshProUGUI CounterText;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerDeck = networkIdentity.GetComponent<PlayerDeck>();

        if (eventData.pointerEnter == PlayerDeckPanel)
        {
            DeckCounter.SetActive(true);
            CounterText.text = PlayerDeck.deck.Count.ToString();
        }
        else if (eventData.pointerEnter == OpponentDeckPanel)
        {
            DeckCounter.SetActive(true);
            CounterText.text = Opponent.GetComponent<Opponent>().deckSize.ToString();
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        DeckCounter.SetActive(false);
    }
}
