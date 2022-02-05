using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float minDist;
    public float maxDist;
    public GameObject[] obstacles;
    private float[] yOffsets;
    public float setTimeBtwSpawn;
    public float timeBtwSpawn;
    public GameObject obstacleHolder;
    public bool started;

    private void Awake()
    {
        yOffsets = new float[obstacles.Length];
        for (int i = 0; i < obstacles.Length; i++)
        {
            yOffsets[i] = obstacles[i].transform.position.y;
        }
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeBtwSpawn -= Time.deltaTime;

        if (started == true)
        {
            if (timeBtwSpawn <= 0)
            {
                int randObst = Random.Range(0, obstacles.Length);
                Vector3 targetPos = new Vector3(transform.position.x, yOffsets[randObst], 0);
                Instantiate(obstacles[randObst], targetPos, Quaternion.identity, obstacleHolder.transform);
                timeBtwSpawn = setTimeBtwSpawn;
            }
        }
    }
}
