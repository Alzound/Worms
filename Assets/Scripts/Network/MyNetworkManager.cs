using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);

        Debug.Log(conn.address);

        var newPlayer = conn.identity.GetComponent<MyNetworkPlayer>();

        newPlayer.SetDisplayName($"Player {numPlayers}");
        var newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        newPlayer.SetColor(newColor);
        Debug.Log($"Join player {numPlayers} the server!!!"); 
    }
}
