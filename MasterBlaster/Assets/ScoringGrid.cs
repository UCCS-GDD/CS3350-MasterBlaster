using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoringGrid : MonoBehaviour {

    public static int w = 12;
    public static int h = 6;
    public GameObject gridCell;
    public static List<GameObject> blocks; 
    int count;
    int maxCount = 20;
    public static List<GameObject> blocksToDestroy;
    public List<GameObject> halp;
    public List<GameObject> allBlocks;

    //make grid
    public static GameObject[,] grid = new GameObject[w, h];


    // Use this for initialization
    void Start()
    {
       blocksToDestroy = new List<GameObject>();
        blocks = new List<GameObject>();
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
        halp = blocksToDestroy;
        allBlocks = blocks; 
        //Debug.Log(blocksToDestroy);
       //Debug.Log(blocksToDestroy.Count);
        //etectFullRow();
        //for (int j = blocksToDestroy.Count - 1; j >= 0; j--)
        //{
        //    //      Destroy(blocksToDestroy[j]);
        //    //Debug.Log(blocksToDestroy[j]);
            
        //}


        if (blocksToDestroy.Count >= 12)

        //if (blocksToDestroy.Count == 12)

        {
            BlockChild.score += 500;
            for (int i = blocksToDestroy.Count - 1; i >= 0; i--)
            {
                //Debug.Log("DESTROY: " + blocksToDestroy.Count.ToString() + " " + blocksToDestroy[i].GetComponent<Collider2D>().bounds.center.ToString());
                blocks.Remove(blocksToDestroy[i].gameObject);
                Destroy(blocksToDestroy[i].gameObject);
                blocksToDestroy.RemoveAt(i);
                
              
                
            }
                

           for (int j = blocks.Count - 1; j >= 0; j--)
            {
                    if (blocks[j] == null)
                    {

                        blocks.RemoveAt(j);
                    }
                    else
                    {
                        blocks[j].gameObject.transform.position -= new Vector3(0, 1);


                    }
                       

            }
               // blocksToDestroy.Clear();
                DetectFullRow();
                //blocks.Clear();
                //count = 0;
        }
                
            
        }

        //blocksToDestroy = blocks;
        
    

    public static void DetectFullRow()
    {

        
        for (int y = h - 1; y >= 0; y--)
        {

           //count = 0;

            //this resets the count in the list 
           blocksToDestroy.Clear();
            for (int x = w - 1; x >= 0; x--)
            {
                for (int i = 0; i < blocks.Count; i++)
                {
                        //overlap testing
                        //if (grid[x, y].GetComponent<Collider2D>().bounds.Intersects(blocks[i].GetComponent<Collider2D>().bounds))
                        //if (blocks[i].GetComponent<Collider2D>() == Physics2D.OverlapPoint(grid[x,y].GetComponent<Collider2D>().bounds.center))
                         //if (grid[x,y].GetComponent<Collider2D>() == Physics2D.OverlapPoint(blocks[i].GetComponent<Collider2D>().bounds.center))
                            if (blocks[i] != null && grid[x,y].GetComponent<Collider2D>().bounds.Contains(blocks[i].GetComponent<Collider2D>().bounds.center))
                        {
                            //count += 1;
                           // Debug.Log(count);
                            GameObject blockD = blocks[i];
                            blocksToDestroy.Add(blockD);
                            //.Log(count.ToString());
                            //Debug.Break();
                            

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
