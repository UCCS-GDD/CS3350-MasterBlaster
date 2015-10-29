using UnityEngine;
using System.Collections;

public class SpawnerScipt : MonoBehaviour {
    //public GameObject grid;    // hold grid
    public GameObject square;  //hold square gameobject
    public GameObject TShape;  //hold Tshape gamebject
    public GameObject LShape;  //hold Lshape gameobject
    GameObject spawnShape;     //hold which shape should spawn - not really needed anymore but keeping it incase of debuggin
    int[] rotationChoices = new int[] {0, 90, 180, 270, 360};
    int howMany;
    int chooseRotation;

    int shape;  //used for case statement
    float time; //used for random time spawning
    Vector3 height;  //used for getting screen coordinates at top
    Vector3 screenCoords;  //used to convert screen coords back to world coords
    int whereSpawnX;    //used for randomizing where to spawn, x value of array
    int whereSpawnY;    //y value of array
    //int whichCollider;   // used for spawning in grid

    Vector2 point;

    

	// Use this for initialization
	void Start () {
        //get random shape, time, and x location
        howMany = rotationChoices.Length;
        chooseRotation = Random.Range(0, howMany);
        shape = Random.Range(1, 4);
        time = Random.Range(3,7);
       
        //the random location is from top grid - will be used as index in array
        whereSpawnX = Random.Range(2,Grid.w - 2);
        whereSpawnY = Random.Range(0, Grid.h);
       
        
	
	}
	
	// Update is called once per frame
	void Update () {
        //Have time constantly go down
        time -= Time.deltaTime;
        //Debug.Log(time);

        

        //hold where the shape can spawn and turn that number into world coordinates
        //height = new Vector3(whereSpawn,1,10);
        //screenCoords = Camera.main.ViewportToWorldPoint(height);
        
        //if it is time to spawn a shape
        if (time <= 0)
        {
            point = Grid.grid[whereSpawnX,whereSpawnY].GetComponent<Collider2D>().bounds.center - Grid.grid[whereSpawnX,whereSpawnY].GetComponent<Collider2D>().bounds.extents;
            //do a swithc statement and based on the number spawn a certain shape, then start the process over of picking time, shape, and location
            switch (shape)
            {
                case 1:
                    spawnShape = square;
                    Instantiate(spawnShape, Grid.grid[whereSpawnX, whereSpawnY].transform.position, Quaternion.Euler(0, 0, rotationChoices[chooseRotation]));
                    shape = Random.Range(1, 4);
                    if (Time.time < 15f)
                    {
                        time = Random.Range(3, 7);
                    }
                    else if (Time.time > 15f && Time.time < 25f)
                    {
                        time = Random.Range(2, 5);
                    }
                    else
                    {
                        time = Random.Range(1, 3);
                    }
                    whereSpawnX = Random.Range(2, Grid.w - 2);
                    whereSpawnY = Random.Range(0, Grid.h);
                    chooseRotation = Random.Range(0, howMany);

                    break;
                case 2:
                    spawnShape = TShape;
                    Instantiate(spawnShape, Grid.grid[whereSpawnX, whereSpawnY].transform.position, Quaternion.Euler(0, 0, rotationChoices[chooseRotation]));
                    shape = Random.Range(1, 4);
                    if (Time.time < 15f)
                    {
                        time = Random.Range(3, 7);
                    }
                    else if (Time.time > 15f && Time.time < 25f)
                    {
                        time = Random.Range(2, 5);
                    }
                    else
                    {
                        time = Random.Range(1, 3);
                    }
                    whereSpawnX = Random.Range(2, Grid.w - 2);
                    whereSpawnY = Random.Range(0, Grid.h);
                    chooseRotation = Random.Range(0, howMany);
                    break;
                case 3:
                    spawnShape = LShape;
                    Instantiate(spawnShape, Grid.grid[whereSpawnX,whereSpawnY].transform.position, Quaternion.Euler(0, 0, rotationChoices[chooseRotation]));
                    shape = Random.Range(1, 4);
                    if (Time.time < 15f)
                    {
                        time = Random.Range(3, 7);
                    }
                    else if (Time.time > 15f && Time.time < 25f)
                    {
                        time = Random.Range(2, 5);
                    }
                    else
                    {
                        time = Random.Range(1, 3);
                    }
                    whereSpawnX = Random.Range(2, Grid.w - 2);
                    whereSpawnY = Random.Range(0, Grid.h);
                    chooseRotation = Random.Range(0, howMany);
                    break;
            }
        }

	}
}
