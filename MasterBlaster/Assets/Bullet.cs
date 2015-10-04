using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //on start add an upward force to the bullet
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	    
        //if it goes off screen and isn't visible anymore destroy itself
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
	}
}
