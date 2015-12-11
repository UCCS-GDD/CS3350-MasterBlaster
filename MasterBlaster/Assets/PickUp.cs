using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
	
	// destroy pickup when it hits the turrett
	void OnTriggerEnter2D (Collider2D collisionObject)
    {
        if (collisionObject.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
	}
}
