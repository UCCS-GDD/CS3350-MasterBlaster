using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.y > 0.02)
        {
            transform.position -= transform.up * Time.deltaTime * 3;

           //GetComponent<Rigidbody2D>().velocity =  new Vector2(0, -3);
   
        }
       // Debug.Log(pos.y);
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            transform.DetachChildren();
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }
}
