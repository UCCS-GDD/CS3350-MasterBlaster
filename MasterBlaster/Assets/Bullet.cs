using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 12), ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
	}
}
