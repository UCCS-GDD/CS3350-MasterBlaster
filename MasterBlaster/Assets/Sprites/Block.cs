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
        //see where the player is relative to screen coordiinates - which are 0 to 1
        Vector3 pos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
           
            //if our turret is on the edge of the screen, set its velocity to 0 and set its position back to the edge of the screen
            if (pos.x < 0.03f)
            {
                pos.x = 0.03f;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                
            }
            if (pos.x > 0.97f)
            {
                pos.x = 0.97f;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            
            //put our pos variable back into world coordinates and use that to determine the turret's position
            transform.position = Camera.main.ViewportToWorldPoint(pos);

        Debug.Log(toMove);

        if (gameObject.tag == "Stationary")
        {
            Debug.Log("yes");
            Transform[] childTs = GetComponentsInChildren<Transform>();

            foreach(Transform trans in childTs)
            {
                trans.gameObject.tag = "Stationary";
            }
        }
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
                    //Debug.Log("Collided with: " + c.gameObject.name);
                    toMove = c.gameObject;
                  
                }
            }
        }
       
        //see where the shapes are relative to the screen
        

        //if the shape is not at the bottom of the screen the shape can fall down
        if (pos.y > 0.05)
        {
            
           GetComponent<Rigidbody2D>().velocity =  new Vector2(0, -1);
   
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
            toMove.GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(0.0001f, 0), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //test to see if it hits specific shapes will it stop moving - also did not work nor did the tag work
        if (coll.gameObject.tag == "Stationary")
        {
            GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.tag = "Stationary";
        }
    }

    bool isValidGridPos()
    {
        Transform[] childs = GetComponentsInChildren<Transform>();
        foreach (Transform child in childs)
        {
            Vector2 v = Grid.roundVec2(child.position);

            // Not inside Border?
            if (!Grid.insideBorder(v))
                return false;

            // Block in grid cell (and not part of same group)?
            if (Grid.grid[(int)v.x, (int)v.y] != null &&
                Grid.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }

    void updateGrid()
    {
        // Remove old children from grid
        for (int y = 0; y < Grid.h; ++y)
            for (int x = 0; x < Grid.w; ++x)
                if (Grid.grid[x, y] != null)
                    if (Grid.grid[x, y].parent == transform)
                        Grid.grid[x, y] = null;

        // Add new children to grid
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.roundVec2(child.position);
            Grid.grid[(int)v.x, (int)v.y] = child;
        }
    }

  
}
