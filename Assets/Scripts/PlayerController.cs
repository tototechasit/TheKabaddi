using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private static Rigidbody rb;
    public static float speed = 10;
    private static Transform player;


	void Start () {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Transform>();
	}
	
	//void FixedUpdate () {
 //       float horizontalMove = Input.GetAxis("Horizontal");
 //       float verticalMove = Input.GetAxis("Vertical");

 //       Vector3 movement = new Vector3(horizontalMove, 0.0f, verticalMove);

 //       moveCharacter(movement);
 //   }

    public static void moveCharacter(Vector3 movement) {
        rb.velocity = movement * speed;


        //player.Translate(movement * speed);

        //Debug.Log("player: " + player.position.x + ", " + player.position.y + ", " + player.position.z + ", ");
    }
}
