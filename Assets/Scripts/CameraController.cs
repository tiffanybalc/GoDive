using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;       
    //public Transform target;
    //public float smoothing;

    private Vector3 offset;         //offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //get the distance between the player's and camera's positions
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;

        //Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
    }
}
