using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LobbyPlayer : NetworkLobbyPlayer
{

    GameObject parentPref;
    public Button joinBtn;
    public Text myText;
    public Text buttonText;
    private bool isPlayerReady = false;


    public void OnClickReadyButton() {

        // Just switch player status (Ready/Not ready)
        if (isPlayerReady)
        {
            SendNotReadyToBeginMessage();
            isPlayerReady = false;
        }
        else
        {
            SendReadyToBeginMessage();
            isPlayerReady = true;
        }
    }
    

    // This method is called every time player enter to this room
    public override void OnClientEnterLobby()
    {
        base.OnClientEnterLobby();

        // Create player's lobby prefab (Player UI in room)
        parentPref = GameObject.FindGameObjectWithTag("PARENTPREF");
        gameObject.transform.SetParent(parentPref.transform);

        Debug.Log("There is player enter the room");
    }


    // This method is called when player's lobby prefab has been set up
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        // Set up player UI
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
        buttonText.text = "Ready";
    }

    private void SetupOtherPlayer() {
        myText.text = "Other player";
        joinBtn.enabled = true;
        buttonText.text = "Join";
    }
}
