using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
    GameObject toMove;

	// Use this for initialization
	void Start () {
        
        //since we don't need rotation, we can constrain the z position right away
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
	}

    
	
	// Update is called once per frame
	void Update () {
        //if mouse is pressed
        if (Input.GetMouseButtonDown(0))
        {
            //get mouse posiiton and set its depth
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 5f;
            
            //see where the mouse is in terms of world coordinates
            Vector2 v = Camera.main.ScreenToWorldPoint(mousePosition);

            //get the colliders the mouse is over
            Collider2D[] col = Physics2D.OverlapPointAll(v);

            //if the mouse is over something
            if (col.Length > 0)
            {
                //set the shape that can be moved to the colliders the mouse is pressing
                foreach (Collider2D c in col)
                {
                    Debug.Log("Collided with: " + c.gameObject.name);
                    toMove = c.gameObject;
                  
                }
            }
        }
       
        //see where the shapes are relative to the screen
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        //if the shape is not at the bottom of the screen the shape can fall down
        if (pos.y > 0.05)
        {
            
           GetComponent<Rigidbody2D>().velocity =  new Vector2(0, -2);
   
        }
        
            //else its at the bottom of the screen, so it isn't moving and its tag SHOULD be set to stationary
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            gameObject.tag = "Stationary";
        }
       
	}

    void FixedUpdate()
    {
        //if A is pressed and we have an object selected, move the shape left
        if (Input.GetKey(KeyCode.A) && toMove != null)
        {
            toMove.GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(-0.0001f, 0), ForceMode2D.Impulse);
        }

        //else move the shape right with D
        else if (Input.GetKey(KeyCode.D) && toMove != null)
        {
            toMove.GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(0001f, 0), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //test to see if it hits specific shapes will it stop moving - also did not work nor did the tag work
        if (coll.gameObject.name == "Lshape" || coll.gameObject.name == "Square" || coll.gameObject.name == "TShape")
        {
            GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.tag = "Stationary";
        }
    }

  
}
