using UnityEngine;
using System.Collections;

public class GridManage : MonoBehaviour {
    int count;
    int maxCount;
    Transform blockPos = BlockChild.gridPos;

	// Use this for initialization
	void Start () {
        count = 0;
        maxCount = 10;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(count);

        //go through one row
        for (int i = 0; i < Grid.w; i++)
        {
            //initially the count will be 0 on that row
            count = 0;

            //go through each column on that row
            for (int j = 0; j < Grid.h; j++)
            {
                //if a block is equal to that row and column position, set the count to be + 1
                if (blockPos = Grid.grid[i,j])
                {
                    count += 1;
                }
            }
        }
	}
}
