using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LobbyCreateManager : MonoBehaviour
{

    public InputField lobbyNameInput;
    public LobbyManager lobbyManager;


    // Create lobby as Host
    public void OnClickCreateButton() {
        lobbyManager.StartMatchMaker();
        lobbyManager.matchMaker.CreateMatch(lobbyNameInput.text, (uint)lobbyManager.maxPlayers, true, "", "", "", 0, 0, lobbyManager.OnMatchCreate);
    }
    
}
