using UnityEngine;
using System.Collections;


public class BlockChild : MonoBehaviour {
   

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {

        //get where the blocks are in relation to the screen
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        //if they are at the bottom of the screen turn the parent's rigidbody off and it SHOULD set a tag - only working for bottom row
       if (pos.y < 0.05f)
        { 
            GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            //GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.tag = "Stationary";
        }

	
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        //if the block is hit by a bullet, destroy the bullet and block
        if (coll.gameObject.tag == "Bullet")
        {

            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
    }

}
