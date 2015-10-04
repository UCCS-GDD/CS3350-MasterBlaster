using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
	}
	
	// Update is called once per frame
	void Update () {
        //Bounds combined = GetComponent<Renderer>().bounds;
        //Renderer[] children = GetComponentsInChildren<Renderer>();
        //foreach (Renderer go in children)
        //{

            //combined.Encapsulate(go.bounds);
            //transform.position = go.bounds.center;

//      GetComponent<Renderer>().bounds.Encapsulate(combined);
        //GetComponent<Renderer>().bounds.h
        //Debug.Log(combined);
        
       
      
       
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.y > 0.05)
        {
            //transform.position -= transform.up * Time.deltaTime * 3;


           GetComponent<Rigidbody2D>().velocity =  new Vector2(0, -2);
   
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            gameObject.tag = "Stationary";
        }
       
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Lshape" || coll.gameObject.name == "Square" || coll.gameObject.name == "TShape")
        {
            GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.tag = "Stationary";
        }
    }
}
