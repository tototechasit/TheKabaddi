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

    // This method is called when player create room
    public override void OnStartHost()
    {
        base.OnStartHost();
        Debug.Log("The game has created as Host...");
        lobby.SetActive(true);
    }

    // This method is called on every client when game change from lobby scene to game play scene.
    public override void OnLobbyClientSceneChanged(NetworkConnection conn)
    {
        base.OnLobbyClientSceneChanged(conn);

        // Hide all lobby UI
        GameObject canvas = GameObject.FindGameObjectWithTag("MAINMENU");
        canvas.SetActive(false);
    }
}
