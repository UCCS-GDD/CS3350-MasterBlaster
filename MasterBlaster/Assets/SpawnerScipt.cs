using UnityEngine;
using System.Collections;

public class SpawnerScipt : MonoBehaviour {
    public GameObject square;
    public GameObject TShape;
    public GameObject LShape;
    int shape;
    float time;

	// Use this for initialization
	void Start () {
        shape = Random.Range(1, 4);
        time = Random.Range(1,4);
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(shape);
        Debug.Log(time);
        time -= Time.deltaTime;

        if (time <= 0)
        {
            switch (shape)
            {
                case 1:
                    Instantiate(square);
                    shape = Random.Range(1, 4);
                    time = Random.Range(1, 4);
                    break;
                case 2:
                    Instantiate(TShape);
                    shape = Random.Range(1, 4);
                    time = Random.Range(1, 4);
                    break;
                case 3:
                    Instantiate(LShape);
                    shape = Random.Range(1, 4);
                    time = Random.Range(1, 4);
                    break;
            }
        }
	
	}
}
