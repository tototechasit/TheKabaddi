using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour {

    private bool isTouch;       // It's boolean checking screen touching.
    private Vector3 pointA;     // It's start point of joystick (tap down on screen).
    private Vector3 pointB;     // It's current point of joystick.

    public Transform outerCircle;       // joystick UI
    public Transform innerCircle;       // joystick UI

    private Vector3 direction;
    private Vector3 offset;

    //private PlayerController playerController;

    void Start() {
        //playerController = gameObject.GetComponent<PlayerController>();
    }


    void Update () {

        if (Input.GetMouseButtonDown(0)) {

            // Get position when tap on mobile screen.
            // "Camera.main.transform.position.y-5" it's -5 because need to let pointA(joystick start position) in y position be 5.
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y-5));

            // Assign joystick start position
            innerCircle.transform.position = pointA;
            outerCircle.transform.position = pointA;

            // Show joystick UI
            innerCircle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;

        } if (Input.GetMouseButton(0)) {
            isTouch = true;
            // Get position while drag on mobile screen
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y - 5));

        } else {
            isTouch = false;
        }
    }

    private void FixedUpdate() {

        if (isTouch) {
            offset = pointB - pointA;
            // "2.0f" 2.0f is distance from inner to outer (inner can't go out of outer).
            direction = Vector3.ClampMagnitude(offset, 1.0f);

            direction.y = 0;

            PlayerController.moveCharacter(direction);
            //moveCharacter(direction * -1);

            Debug.Log(direction.x + ", " + direction.y + ", " + direction.z);

            // Change joystick UI position
            innerCircle.transform.position = new Vector3(pointA.x + direction.x, pointA.y + direction.y, pointA.z + direction.z);
        } else {
            // Hide joystick UI
            innerCircle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
