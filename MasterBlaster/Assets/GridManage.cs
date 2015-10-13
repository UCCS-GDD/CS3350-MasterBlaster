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
        for (int i = 0; i < Grid.w; i++)
        {
            count = 0;
            for (int j = 0; j < Grid.h; j++)
            {
                if (blockPos = Grid.grid[i,j])
                {
                    count += 1;
                }
            }
        }
	}
}
