using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckCount : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{


    public GameObject PlayerDeck;
    public GameObject Opponent;
    public GameObject PlayerDeckPanel;
    public GameObject OpponentDeckPanel;
    public GameObject DeckCounter;
    public TextMeshProUGUI CounterText;

    private void Start()
    {

    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {

        if (eventData.pointerEnter == PlayerDeckPanel)
        {
            DeckCounter.SetActive(true);
            CounterText.text = PlayerDeck.GetComponent<PlayerDeck>().deck.Count.ToString();
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
