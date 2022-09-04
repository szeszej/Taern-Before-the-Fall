using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDeckCount : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject cardCounter;
    public TextMeshProUGUI cardCounterText;
    public GameObject playerDeck; 


    private void Start()
    {
        cardCounter.SetActive(false);
        
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        cardCounterText.text = playerDeck.GetComponent<PlayerDeck>().deck.Count.ToString();
        cardCounter.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        cardCounter.SetActive(false);
    }
}
