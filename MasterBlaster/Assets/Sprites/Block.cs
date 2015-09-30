using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.y > -0.75)
        {
            //transform.position -= transform.up * Time.deltaTime * 3;

           GetComponent<Rigidbody2D>().velocity =  new Vector2(0, -3);
   
        }
        else
        {
            //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
           GetComponent<Rigidbody2D>().isKinematic = true;
        }
       Debug.Log(pos.y);
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        
    }
}
