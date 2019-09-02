using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaLife : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.gameObject.layer.ToString() == "Player")
        {
            //scubadiver.instance.health -= 10f;
            scubadiver.instance.score -= 10;
            PlayerPrefs.SetInt("Score", scubadiver.instance.score);
            print("Collided with sea life");
        }
        */
       
    }
}
