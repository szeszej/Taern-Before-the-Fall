using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    private void Awake()
    {
        cardList.Add(new Card(0, "Taernijski Wieœniak", "", "£apaj samogon!", 1, 1, 1, 1, Resources.Load<Sprite>("farmer")));
        cardList.Add(new Card(1, "Taernijski Rycerz", "", "Po prostu rycerz.", 2, 3, 3, 1, Resources.Load<Sprite>("cavalry")));
        cardList.Add(new Card(2, "Taernijski Mag Ognia", "", "Strze¿ siê ognia.", 4, 2, 4, 2, Resources.Load<Sprite>("sun-priest")));
        cardList.Add(new Card(3, "Taernijski £ucznik", "", "Salwa!", 2, 2, 2, 2, Resources.Load<Sprite>("archer")));
        cardList.Add(new Card(4, "Taernijski Druid", "", "Za naturê!", 2, 4, 4, 3, Resources.Load<Sprite>("healing")));
    }
}

