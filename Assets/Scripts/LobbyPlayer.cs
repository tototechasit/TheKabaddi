using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LobbyPlayer : NetworkLobbyPlayer
{

    public GameObject parentPref;
    public Button joinBtn;
    public Text myText;
    public Text buttonText;

    public void OnClickJoinButton() {
        SendReadyToBeginMessage();

        // just added
        GameObject canvas = GameObject.FindGameObjectWithTag("MAINMENU");
        canvas.SetActive(false);
    }

    public override void OnClientEnterLobby()
    {
        base.OnClientEnterLobby();

        parentPref = GameObject.FindGameObjectWithTag("PARENTPREF");

        gameObject.transform.SetParent(parentPref.transform);
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        if (isLocalPlayer)
        {
            SetupLocalPlayer();
        }
        else {
            SetupOtherPlayer();
        }
    }

    private void SetupLocalPlayer() {
        myText.text = "My player";
        joinBtn.enabled = true;
        buttonText.text = "Join";
    }

    private void SetupOtherPlayer() {
        myText.text = "Other player";
        joinBtn.enabled = true;
        buttonText.text = "Join";
    }
}
