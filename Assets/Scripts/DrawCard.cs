using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Unity.VisualScripting;

public class DrawCard : NetworkBehaviour
{

    public PlayerDeck PlayerDeck;

    public void OnClick()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerDeck = networkIdentity.GetComponent<PlayerDeck>();
        PlayerDeck.CmdDraw(1);
    }

}
