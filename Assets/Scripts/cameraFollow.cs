using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour{
    public Transform target;
    public float smoothSpeed = .125f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;    

    void Update(){
        // locating targetLocation + offest position
        Vector3 desiredPosition = target.position + offset;
        //smoothly matching camera location to targetLocation
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed*Time.deltaTime);
        //actually resetting the position 
        transform.position = smoothPosition;
        //transform.LookAt(target); if you want to focus player in 3d space
    }
}
