using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(15, 30) * Time.deltaTime);
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Projectile>()) {
            scubadiver.instance.score += 100;
            PlayerPrefs.SetInt("Score", scubadiver.instance.score);
            Destroy(gameObject);
        }
        else if(collision.gameObject.layer.ToString() == "Player") {
            scubadiver.instance.score += 100;
            PlayerPrefs.SetInt("Score", scubadiver.instance.score);
            Destroy(gameObject);
        }
    }
}
