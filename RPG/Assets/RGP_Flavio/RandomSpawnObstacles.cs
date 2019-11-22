using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnObstacles : MonoBehaviour
{
    public GameObject[] obstacleInventory;
    [Tooltip("from -x, to x; from -y to y; from -z to z")]
    public Vector3 spawnRange;
    public bool spawnObstacles;
    public uint obstaclesInLevelCount;

    bool obstaclesCreated;
    public bool drawDebugLines;

    // Start is called before the first frame update
    void Start()
    {
        spawnObstacles = false;
        obstaclesCreated = false;
    }

    void SpawnObstacles(uint count) // Count : How many obstacles to spawn
    {

        int index = 0;
        Vector3 spawnPosition;
        for (int i = 0; i < count; ++i)
        {
            index = Random.Range(0, obstacleInventory.Length);
            spawnPosition = new Vector3(Random.Range(-spawnRange.x, spawnRange.x),
                                               Random.Range(-spawnRange.y, spawnRange.y),
                                               Random.Range(-spawnRange.z, spawnRange.z));


            Instantiate(obstacleInventory[index], spawnPosition + transform.TransformPoint(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }
    }


    void DebugDrawSpawnRange()
    {

        var bottomRightCorner = new Vector3(transform.TransformPoint(0.0f, 0.0f, 0.0f).x + (-spawnRange.x),
              transform.TransformPoint(0.0f, 0.0f, 0.0f).y + (-spawnRange.y),
              transform.TransformPoint(0.0f, 0.0f, 0.0f).z + (-spawnRange.z));

        var upperRightCorner = new Vector3(transform.TransformPoint(0.0f, 0.0f, 0.0f).x + (-spawnRange.x),
            transform.TransformPoint(0.0f, 0.0f, 0.0f).y + (spawnRange.y),
            transform.TransformPoint(0.0f, 0.0f, 0.0f).z + (-spawnRange.z));

        var upperLeftCorner = new Vector3(transform.TransformPoint(0.0f, 0.0f, 0.0f).x + (spawnRange.x),
           transform.TransformPoint(0.0f, 0.0f, 0.0f).y + (spawnRange.y),
           transform.TransformPoint(0.0f, 0.0f, 0.0f).z + (-spawnRange.z));

        var bottomLeftCorner = new Vector3(transform.TransformPoint(0.0f, 0.0f, 0.0f).x + (spawnRange.x),
              transform.TransformPoint(0.0f, 0.0f, 0.0f).y + (-spawnRange.y),
              transform.TransformPoint(0.0f, 0.0f, 0.0f).z + (-spawnRange.z));


       var opositeBottomRightCorner = new Vector3(transform.TransformPoint(0.0f, 0.0f, 0.0f).x + (-spawnRange.x),
              transform.TransformPoint(0.0f, 0.0f, 0.0f).y + (-spawnRange.y),
              transform.TransformPoint(0.0f, 0.0f, 0.0f).z + (spawnRange.z));
       var opositeUpperRightCorner = new Vector3(transform.TransformPoint(0.0f, 0.0f, 0.0f).x + (-spawnRange.x),
            transform.TransformPoint(0.0f, 0.0f, 0.0f).y + (spawnRange.y),
            transform.TransformPoint(0.0f, 0.0f, 0.0f).z + (spawnRange.z));

        var opositeUpperLeftCorner = new Vector3(transform.TransformPoint(0.0f, 0.0f, 0.0f).x + (spawnRange.x),
           transform.TransformPoint(0.0f, 0.0f, 0.0f).y + (spawnRange.y),
           transform.TransformPoint(0.0f, 0.0f, 0.0f).z + (spawnRange.z));

        var oppositeBottomLeftCorner = new Vector3(transform.TransformPoint(0.0f, 0.0f, 0.0f).x + (spawnRange.x),
              transform.TransformPoint(0.0f, 0.0f, 0.0f).y + (-spawnRange.y),
              transform.TransformPoint(0.0f, 0.0f, 0.0f).z + (spawnRange.z));

        var center = new Vector3(transform.TransformPoint(0.0f, 0.0f, 0.0f).x,
         transform.TransformPoint(0.0f, 0.0f, 0.0f).y,
         transform.TransformPoint(0.0f, 0.0f, 0.0f).z);

        //Debug.DrawLine(center, opositeUpperLeftCorner, Color.red);
        //Debug.DrawLine(center, oppositeBottomLeftCorner, Color.red);
        Debug.DrawLine(oppositeBottomLeftCorner, opositeUpperLeftCorner, Color.red);

        //Cross
        Debug.DrawLine(upperRightCorner, opositeUpperLeftCorner, Color.red);
        //Cross
        Debug.DrawLine(upperLeftCorner, opositeUpperRightCorner, Color.red);

        Debug.DrawLine(opositeUpperRightCorner, opositeUpperLeftCorner, Color.black);
        Debug.DrawLine(opositeBottomRightCorner, oppositeBottomLeftCorner, Color.black);


        Debug.DrawLine(upperLeftCorner, opositeUpperLeftCorner, Color.white);
        Debug.DrawLine(bottomLeftCorner, oppositeBottomLeftCorner, Color.white);


        //Debug.DrawLine(center, opositeUpperRightCorner, Color.blue);
        //Debug.DrawLine(center, opositeBottomRightCorner, Color.blue);
        Debug.DrawLine(opositeBottomRightCorner, opositeUpperRightCorner, Color.blue);

        Debug.DrawLine(upperRightCorner, opositeUpperRightCorner, Color.cyan);
        Debug.DrawLine(opositeBottomRightCorner, bottomRightCorner, Color.cyan);

        //Debug.DrawLine(center, upperRightCorner, Color.yellow);
        //Debug.DrawLine(center, bottomRightCorner, Color.yellow);
        Debug.DrawLine(bottomRightCorner, upperRightCorner, Color.yellow);


        //Debug.DrawLine(center, upperLeftCorner, Color.yellow);
        Debug.DrawLine(upperRightCorner, upperLeftCorner, Color.yellow);
        Debug.DrawLine(bottomRightCorner, bottomLeftCorner, Color.yellow);


        //Debug.DrawLine(center, upperLeftCorner, Color.yellow);
        //Debug.DrawLine(center, bottomLeftCorner, Color.yellow);
        Debug.DrawLine(bottomLeftCorner, upperLeftCorner, Color.magenta);

    }



    // Update is called once per frame
    void Update()
    {
        if (!spawnObstacles)
            obstaclesCreated = false;

        if (spawnObstacles && !obstaclesCreated)
        {
            if (obstaclesInLevelCount != 0)
            {
                SpawnObstacles(obstaclesInLevelCount);
                obstaclesCreated = true;
            }
        }

        if(drawDebugLines)
            DebugDrawSpawnRange();

    }
}
