using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform trackedTarget;
    private Vector3 offset;         // offset is beginning position of camera


	void Start () {
        offset = transform.position;
    }


    void LateUpdate()
    {

        transform.position = offset + trackedTarget.transform.position;
    }
}
