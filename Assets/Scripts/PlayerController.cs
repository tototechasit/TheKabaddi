using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    private static Rigidbody rb;        // It's player movement component.
    public float speed;                 // Fixed value for control player movement speed.

    public Joystick joystick;        // Game controller.


    // Get movement command from Joystick.
    void Update()
    {
        if (!isLocalPlayer)
            return;
        

        float horizontalMove = joystick.Horizontal;
        float verticalMove = joystick.Vertical;

        Vector3 movement = new Vector3(horizontalMove, 0, verticalMove);

        rb.velocity = movement * speed; // Move player
        
    }

    // This method is called when player object has been set up
    public override void OnStartLocalPlayer()
    {
        rb = GetComponent<Rigidbody>();

        joystick = FindObjectOfType<Joystick>();

        Debug.Log(GetComponent<Transform>().position.x + " : " + GetComponent<Transform>().position.z);

        Camera.main.GetComponent<CameraController>().trackedTarget = GetComponent<Transform>(); // Fix camera to follow Player
    }

}
