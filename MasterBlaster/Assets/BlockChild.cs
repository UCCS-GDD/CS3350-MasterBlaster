using UnityEngine;
using System.Collections;


public class BlockChild : MonoBehaviour {
    public static int score;
    public static Transform gridPos;

   

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(GetComponentInChildren<SpriteRenderer>().sprite.pixelsPerUnit);
        //Debug.Log(gridPos);

        ////try to get position on grid of each block 
        //for (int i = 0; i < Grid.w; i++)
        //{
        //    for (int j = 0; j < Grid.h; j++)
        //    {
        //        if (transform == Grid.grid[i, j])
        //        {
        //            gridPos = Grid.grid[i, j];
        //        }
        //    }
        //}
        //get where the blocks are in relation to the screen
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        //if they are at the bottom of the screen turn the parent's rigidbody off and it SHOULD set a tag - only working for bottom row
       if (pos.y < 0.043)
        { 
            GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            //GetComponent<Rigidbody2D>().isKinematic = true;
            transform.parent.tag = "Stationary";
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
    }

    

}
