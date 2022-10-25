using UnityEngine;

public class Combat : MonoBehaviour
{

    public GameObject PlayerHp;
    public GameObject OpponentHp;

    private GameObject[] playerZones;
    private GameObject[] opponentZones;

    public void CommenceCombat(GameObject[] playerSide, GameObject[] opponentSide)
    {
        playerZones = playerSide;
        opponentZones = opponentSide;

        for (int i = 0; i < playerZones.Length; i++)
        {
            //if there are cards on each side
            if (playerZones[i].transform.childCount > 0 && opponentZones[i].transform.childCount > 0)
            {
                Clash(playerZones[i].transform.GetChild(0).GetComponent<DisplayCard>().displayCard, opponentZones[i].transform.GetChild(0).GetComponent<DisplayCard>().displayCard);
            }
            //if there's only a card on the player side
            else if (playerZones[i].transform.childCount > 0 && opponentZones[i].transform.childCount == 0)
            {
                OpponentHp.GetComponent<Opponent>().TakeDamage(playerZones[i].transform.GetChild(0).GetComponent<DisplayCard>().displayCard.attack);
            }
            //if there's only a card on the opponent side
            else if (playerZones[i].transform.childCount == 0 && opponentZones[i].transform.childCount > 0)
            {
                PlayerHp.GetComponent<PlayerHp>().TakeDamage(opponentZones[i].transform.GetChild(0).GetComponent<DisplayCard>().displayCard.attack);
            }
        }
    }

    private void Clash(Card playerCard, Card opponentCard)
    {

        if (playerCard.speed == opponentCard.speed)
        {
            playerCard.hp -= opponentCard.attack;
            opponentCard.hp -= playerCard.attack;
            CheckCasualties();
        }
        else if (playerCard.speed < opponentCard.speed)
        {
            playerCard.hp -= opponentCard.attack;
            CheckCasualties();
            if (playerCard.hp > 0)
            {
                opponentCard.hp -= playerCard.attack;
                CheckCasualties();
            }

        }
        else if (playerCard.speed > opponentCard.speed)
        {
            opponentCard.hp -= playerCard.attack;
            CheckCasualties();
            if (opponentCard.hp > 0)
            {
                playerCard.hp -= opponentCard.attack;
                CheckCasualties();
            }

        }
    }

    private void CheckCasualties()
    {
        for (int i = 0; i < playerZones.Length; i++)
        {
            if (playerZones[i].transform.childCount > 0 && playerZones[i].transform.GetChild(0).GetComponent<DisplayCard>().displayCard.hp <= 0)
            {
                playerZones[i].GetComponent<CardDropZone>().DiscardCard(playerZones[i].transform.GetChild(0).gameObject);
            }
            if (opponentZones[i].transform.childCount > 0 && opponentZones[i].transform.GetChild(0).GetComponent<DisplayCard>().displayCard.hp <= 0)
            {
                opponentZones[i].GetComponent<OppCardDropZone>().DiscardCard(opponentZones[i].transform.GetChild(0).gameObject);
            }
        }
    }
}
