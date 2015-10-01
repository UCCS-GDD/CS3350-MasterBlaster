using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Bounds combined = GetComponent<Renderer>().bounds;
        Renderer[] children = GetComponentsInChildren<Renderer>();
        foreach (Renderer go in children)
        {
            combined.Encapsulate(go.bounds);
            
        
  
        }

        GetComponent<Renderer>().bounds.Encapsulate(combined);
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
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
           //GetComponent<Rigidbody2D>().isKinematic = true;
           gameObject.tag = "Stationary";
        }
       
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Stationary")
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
