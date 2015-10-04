using UnityEngine;
using System.Collections;

public class SpawnerScipt : MonoBehaviour {
    public GameObject square;  //hold square gameobject
    public GameObject TShape;  //hold Tshape gamebject
    public GameObject LShape;  //hold Lshape gameobject
    GameObject spawnShape;     //hold which shape should spawn - not really needed anymore but keeping it incase of debuggin

    int shape;  //used for case statement
    float time; //used for random time spawning
    Vector3 height;  //used for getting screen coordinates at top
    Vector3 screenCoords;  //used to convert screen coords back to world coords
    float whereSpawn;      //used for randomizing where to spawn

	// Use this for initialization
	void Start () {
        //get random shape, time, and x location
        shape = Random.Range(1, 4);
        time = Random.Range(1,4);

        //the random location is from 0 to one because it will be in viewport/screen coordinates
        whereSpawn = Random.Range(0.0f, 1.0f);
	
	}
	
	// Update is called once per frame
	void Update () {
        //Have time constantly go down
        time -= Time.deltaTime;

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
                    Instantiate(spawnShape, screenCoords, Quaternion.identity);
                    shape = Random.Range(1, 4);
                    time = Random.Range(1, 4);
                    whereSpawn = Random.Range(0.0f, 1.0f);

                    break;
                case 2:
                    spawnShape = TShape;
                    Instantiate(spawnShape, screenCoords, Quaternion.identity);
                    shape = Random.Range(1, 4);
                    time = Random.Range(1, 4);
                    whereSpawn = Random.Range(0.0f, 1.0f);
                    break;
                case 3:
                    spawnShape = LShape;
                    Instantiate(spawnShape, screenCoords, Quaternion.identity);
                    shape = Random.Range(1, 4);
                    time = Random.Range(1, 4);
                    whereSpawn = Random.Range(0.0f, 1.0f);
                    break;
            }
        }

	}
}
