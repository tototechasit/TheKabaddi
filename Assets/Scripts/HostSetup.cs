using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class HostSetup : MonoBehaviour
{

    MatchInfoSnapshot match;
    public Text hostName;

    LobbyManager lobbyManager;
    GameObject lobbyParent;

    private void Start()
    {
        lobbyManager = GameObject.FindGameObjectWithTag("LMANAGER").GetComponent<LobbyManager>();
        lobbyParent = GameObject.FindGameObjectWithTag("LOBBYPARENT");
    }

    public void Setup(MatchInfoSnapshot match)
    {
        this.match = match;
        hostName.text = this.match.name;
    }

    public void Join()
    {
        if (lobbyManager == null)
        {
            lobbyManager = GameObject.FindGameObjectWithTag("LMANAGER").GetComponent<LobbyManager>();
        }

        var gameObj = lobbyParent.GetComponentsInChildren<Transform>(true);
        foreach (var item in gameObj)
        {
            item.gameObject.SetActive(true);
        }

        lobbyManager.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, lobbyManager.OnMatchJoined);


    }

}
