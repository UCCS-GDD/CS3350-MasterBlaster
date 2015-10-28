using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoringGrid : MonoBehaviour {

    public static int w = 12;
    public static int h = 6;
    public GameObject gridCell;
    public static List<GameObject> blocks = new List<GameObject>();
    int count;
    int maxCount = 12;
    public static List<GameObject> blocksToDestroy = new List<GameObject>();

    //make grid
    public static GameObject[,] grid = new GameObject[w, h];


    // Use this for initialization
    void Start()
    {
       count = 0;

        //go through list and column and set the positions equal to a multiple of 64 (1 unit in unity is set to 64 pixels)
        for (int x = 0; x < w; x++)
        {
            for (int y = 0; y < h; y++)
            {
                grid[x, y] = Instantiate(gridCell, new Vector2(x - 5, Camera.main.ViewportToWorldPoint(new Vector3(0,0)).y + y + 0.5f), Quaternion.identity) as GameObject;
                grid[x, y].tag = "Grid";

            }
        }        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(blocksToDestroy.Count);
        //etectFullRow();
        //for (int j = blocksToDestroy.Count - 1; j >= 0; j--)
        //{
        //    //      Destroy(blocksToDestroy[j]);
        //    //Debug.Log(blocksToDestroy[j]);
            
        //}
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
       
    }

    public void DetectFullRow()
    {

        for (int x = w - 1; x >= 0; x--)
        {

            count = 0;
            for (int y = h - 1; y >= 0; y--)
            {
                for (int i = 0; i < blocks.Count; i++)
                {
                        
                        //overlap testing
                        //if (grid[x, y].GetComponent<Collider2D>().bounds.Intersects(blocks[i].GetComponent<Collider2D>().bounds))
                        //if (blocks[i].GetComponent<Collider2D>() == Physics2D.OverlapPoint(grid[x,y].GetComponent<Collider2D>().bounds.center))
                         if (grid[x,y].GetComponent<Collider2D>() == Physics2D.OverlapPoint(blocks[i].GetComponent<Collider2D>().bounds.center))
                        {
                            count += 1;
                           // Debug.Log(count);
                            //Debug.Break();
                           // blocksToDestroy.Add(blocks[i]);

                           //todo: change blocks to red
                            blocks[i].GetComponent<SpriteRenderer>().color = Color.red;
                            



                        }
                    
                }
            }
        }

        //if (count == maxCount)
        //{
           
        //}
        
    }


}
