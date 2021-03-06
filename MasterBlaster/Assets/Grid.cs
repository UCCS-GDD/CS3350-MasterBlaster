﻿using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{
    public static int w = 12;
    public static int h = 3;
    public GameObject gridCell;




    //make grid
    public static GameObject[,] grid = new GameObject[w, h];


    // Use this for initialization
    void Start()
    {


        //go through list and column and set the positions equal to a multiple of 64 (1 unit in unity is set to 64 pixels)
        for (int x = 0; x < w; x++)
        {
            for (int y = 0; y < h; y++)
            {
                grid[x, y] = Instantiate(gridCell, new Vector2(x - 5, Camera.main.ViewportToWorldPoint(new Vector3(0, 1)).y + y + 0.5f), Quaternion.identity) as GameObject;

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}
