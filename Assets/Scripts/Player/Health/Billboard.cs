using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    //Reference to the camera
    private Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;
    }

    //Called after the regular update
    //So the camera make all the movement, and then we point towards it
    private void LateUpdate()
    {
        //Point this object towards a target
        //Point the billboard in the same direction as the camera   
        transform.LookAt(transform.position + cam.forward);
    }
}
