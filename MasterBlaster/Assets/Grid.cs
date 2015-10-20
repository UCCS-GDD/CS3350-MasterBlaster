using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    public static int w = 10;
    public static int h = 20;
    //public static int cell_width = 64;
    //public static int cell_height = 64;
    public static Transform[,] grid = new Transform[w, h];

	// Use this for initialization
	void Start () {
        for (int x = 0; x < w; x++ )
        {
            for (int y = 0; y < h; y++)
            {
                grid[x,y].transform.position = (new Vector3(x * 1, -y * 1));
            }
        }

        foreach (Transform t in grid)
        {
            //t.SetAsFirstSibling();
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	}


    
  }

