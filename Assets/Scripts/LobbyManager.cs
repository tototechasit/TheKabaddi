using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LobbyManager : NetworkLobbyManager
{

    public GameObject lobby;

    public void Start()
    {
        lobby.SetActive(false);
    }

    public override void OnStartHost()
    {
        base.OnStartHost();
        Debug.Log("The game has created as Host...");
        lobby.SetActive(true);
    }


}
