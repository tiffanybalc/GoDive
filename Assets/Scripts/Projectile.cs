using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    //Outlets
    Rigidbody rigidbody;

    //State Tracking
    Transform target;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * 10);
        rigidbody.velocity = transform.forward * 10;
	}

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Pick Up" || collision.gameObject.tag == "SeaLife") {
            Destroy(collision.gameObject);

        }
        Destroy(gameObject);
        GameObject explosion = Instantiate(scubadiver.instance.explosionPrefab, collision.transform.position, Quaternion.identity);
        Destroy(explosion, 0.25f);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
