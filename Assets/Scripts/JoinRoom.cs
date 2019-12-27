using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;

public class JoinRoom : MonoBehaviour
{

    LobbyManager lobbyManager;
    public GameObject PrefabForHost;
    public GameObject ParentForHost;


    void Start()
    {
        lobbyManager = GameObject.FindGameObjectWithTag("LMANAGER").GetComponent<LobbyManager>();
    }

    public void RefreshList() {
        if (lobbyManager == null) {
            lobbyManager = GameObject.FindGameObjectWithTag("LMANAGER").GetComponent<LobbyManager>();
        }
        if (lobbyManager.matchMaker == null) {
            lobbyManager.StartMatchMaker();
        }

        lobbyManager.matchMaker.ListMatches(0, 20, "", true, 0, 0, onMatchList);
    }

    private void onMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList)
    {
        if (!success)
        {
            Debug.Log("Please refresh...");
        }

        foreach(MatchInfoSnapshot match in matchList)
        {
            GameObject listGameObj = Instantiate(PrefabForHost);
            listGameObj.transform.SetParent(ParentForHost.transform);
            HostSetup hostSetup = listGameObj.GetComponent<HostSetup>();
            hostSetup.Setup(match);
        }
    }
}
