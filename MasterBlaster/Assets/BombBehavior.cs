using UnityEngine;
using System.Collections;

public class BombBehavior : MonoBehaviour {

    Rigidbody2D RB2D;

	// Use this for initialization
	void Start () {
        RB2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.tag == "Block")
        {
            Debug.Log("destroying block" + collisionObject.tag);
            Destroy(collisionObject.transform.root.gameObject);
            Destroy(gameObject);
        }
    }


	
	}

