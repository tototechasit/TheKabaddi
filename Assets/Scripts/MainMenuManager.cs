using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public LobbyManager lobbyManager;
    public GameObject createLobbyPanel;

    public GameObject joinRoomObj;
    JoinRoom joinRoom;


    public void Start()
    {
        createLobbyPanel.SetActive(false);
    }

    public void OnClickCreateLobby() {
        createLobbyPanel.SetActive(true);
    }

    public void OnClickFindLobby() {
        lobbyManager.StartMatchMaker();
        joinRoomObj.SetActive(true);
        joinRoom = joinRoomObj.GetComponent<JoinRoom>();
        joinRoom.RefreshList();
    }

    public void OnClickQuickJoin() {

    }
}
