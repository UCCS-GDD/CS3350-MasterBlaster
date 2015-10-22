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
    float whereSpawn;      //used for randomizing where to spawn
    //int whichCollider;   // used for spawning in grid
    

	// Use this for initialization
	void Start () {
        //get random shape, time, and x location
        howMany = rotationChoices.Length;
        chooseRotation = Random.Range(0, howMany);
        shape = Random.Range(1, 4);
        time = Random.Range(3,7);
       
        //the random location is from 0 to one because it will be in viewport/screen coordinates
        whereSpawn = Random.Range(1, 12);
        
	
	}
	
	// Update is called once per frame
	void Update () {
        //Have time constantly go down
        time -= Time.deltaTime;
        Debug.Log(time);

        //hold where the shape can spawn and turn that number into world coordinates
        height = new Vector3(whereSpawn,1,10);
        screenCoords = Camera.main.ViewportToWorldPoint(height);
        
        //if it is time to spawn a shape
        if (time <= 0)
        {
            //do a swithc statement and based on the number spawn a certain shape, then start the process over of picking time, shape, and location
            switch (shape)
            {
                case 1:
                    spawnShape = square;
                    Instantiate(spawnShape, screenCoords, Quaternion.Euler(0,0,rotationChoices[chooseRotation]));
                    shape = Random.Range(1, 4);
                    if (Time.time < 10f)
                    {
                        time = Random.Range(3, 7);
                    }
                    else if (Time.time > 10f && Time.time < 20f)
                    {
                        time = Random.Range(2, 5);
                    }
                    else
                    {
                        time = Random.Range(1, 3);
                    }
                    whereSpawn = Random.Range(0.03f, 0.97f);
                    chooseRotation = Random.Range(0, howMany);

                    break;
                case 2:
                    spawnShape = TShape;
                    Instantiate(spawnShape, screenCoords, Quaternion.Euler(0, 0, rotationChoices[chooseRotation]));
                    shape = Random.Range(1, 4);
                    if (Time.time < 10f)
                    {
                        time = Random.Range(3, 7);
                    }
                    else if (Time.time > 10f && Time.time < 20f)
                    {
                        time = Random.Range(2, 5);
                    }
                    else
                    {
                        time = Random.Range(1, 3);
                    }
                    whereSpawn = Random.Range(0.03f, 0.97f);
                    chooseRotation = Random.Range(0, howMany);
                    break;
                case 3:
                    spawnShape = LShape;
                    Instantiate(spawnShape, screenCoords, Quaternion.Euler(0, 0, rotationChoices[chooseRotation]));
                    shape = Random.Range(1, 4);
                    if (Time.time < 10f)
                    {
                        time = Random.Range(3, 7);
                    }
                    else if (Time.time > 10f && Time.time < 20f)
                    {
                        time = Random.Range(2, 5);
                    }
                    else
                    {
                        time = Random.Range(1, 3);
                    }
                    whereSpawn = Random.Range(0.03f, 0.97f);
                    chooseRotation = Random.Range(0, howMany);
                    break;
            }
        }

	}
}
