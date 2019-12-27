using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    private static Rigidbody rb;        // It's player movement component.
    public float speed;                 // Fixed value for control player movement speed.
    private static Transform player;    // Player object.

    protected Joystick joystick;        // Game controller.


	void Start () {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Transform>();

        joystick = FindObjectOfType<Joystick>();
	}

    // Get movement command from Joystick.
    void FixedUpdate() {
        if (!isLocalPlayer)
            return;

        float horizontalMove = joystick.Horizontal;
        float verticalMove = joystick.Vertical;

        Vector3 movement = new Vector3(horizontalMove, 0, verticalMove);

        MoveCharacter(movement);
    }

    // Move player.
    public void MoveCharacter(Vector3 movement) {
        rb.velocity = movement * speed;
    }

    public override void OnStartLocalPlayer() {
        Camera.main.GetComponent<CameraController>().trackedTarget = transform; // Fix camera to follow Player

    }
}
