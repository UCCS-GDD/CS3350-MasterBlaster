using UnityEngine;
using System.Collections;

public class SpawnerScipt : MonoBehaviour {
    public GameObject square;
    public GameObject TShape;
    public GameObject LShape;
    GameObject spawnShape;
    int shape;
    float time;
    Vector3 height;
    Vector3 screenCoords;
    float whereSpawn;

	// Use this for initialization
	void Start () {
        shape = Random.Range(1, 4);
        time = Random.Range(1,4);
        whereSpawn = Random.Range(0.0f, 1.0f);
	
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(shape);
        //Debug.Log(time);
        time -= Time.deltaTime;
        height = new Vector3(whereSpawn,1,10);
        screenCoords = Camera.main.ViewportToWorldPoint(height);
        
        if (time <= 0)
        {
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
