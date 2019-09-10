using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;       // get player for letting camera can follow
    private Vector3 offset;         // offset is beginning position of camera

	void Start () {
        //player = GameObject.Find("Player(Clone)");
        offset = transform.position - player.transform.position;
	}
	

	void LateUpdate () {
        transform.position = offset + player.transform.position;
	}
}
