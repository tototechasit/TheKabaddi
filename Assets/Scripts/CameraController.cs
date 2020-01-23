using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform trackedTarget; // default set from PlayerController script when player is spawn
    private Vector3 offset;         // offset is beginning position of camera


	void Start () {
        offset = transform.position;
    }


    void LateUpdate()
    {
        if (trackedTarget != null)
        {
            transform.position = offset + trackedTarget.transform.position;
        }
    }
}
