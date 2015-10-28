using UnityEngine;
using System.Collections;


public class BlockChild : MonoBehaviour {
    public static int score;
    public static GameObject gridPos;
    //int count = 0;
    int maxCount = 10;
    //public static int count1 = 0;
   

	// Use this for initialization
	void Start () {

        //ScoringGrid.blocks.Add(gameObject);
	}
	
	// Update is called once per frame
    void Update()
    {
        
        //do one variable for each or move to collision code

        //Debug.Log(GetComponentInChildren<SpriteRenderer>().sprite.pixelsPerUnit);
        //try to get position on grid of each block 
        //for (int i = 0; i < ScoringGrid.w; i++)
        // {
        //    for (int j = 0; j < ScoringGrid.h; j++)
        //    {
        //        if (GetComponent<Collider2D>().bounds.Intersects(ScoringGrid.grid[i, j].GetComponent<BoxCollider2D>().bounds))
        //        {
        //            gridPos = ScoringGrid.grid[i, j];
        //            //Debug.Log("colliding with grid");
        //        }
        //    }
        //}
        //get where the blocks are in relation to the screen
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        //if they are at the bottom of the screen turn the parent's rigidbody off and it SHOULD set a tag
        if (pos.y < 0.043)
        {
            GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            //GetComponent<Rigidbody2D>().isKinematic = true;
            transform.parent.tag = "Stationary";
            tag = "Stationary";
        }


    }

   

    void OnTriggerEnter2D(Collider2D coll)
    {
        //if the block is hit by a bullet, destroy the bullet and block
        if (coll.gameObject.tag == "Bullet" && gameObject.tag != "Stationary")
        {
            score += 5;
            Destroy(gameObject);
            Destroy(coll.gameObject);
     
        }

        //if (tag == "Stationary" && coll.gameObject.tag == "Grid")
        //{
        //    //go through one row
        //    for (int i = 0; i < ScoringGrid.w; i++)
        //    {
        //        //initially the count will be 0 on that row
        //        count = 0;

        //        //go through each column on that row
        //        for (int j = 0; j < ScoringGrid.h; j++)
        //        {

        //            //if a block is equal to that row and column position, set the count to be + 1
        //            if (coll.gameObject == ScoringGrid.grid[i,j])
        //            {
        //                count += 1;

        //            }


        //        }
        //    }
        //}
    }

    void OnTriggerStay2D(Collider2D coll)
    {
     
    }

    

}
