using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public float setTimeBtwSpawn;
    private float timeBtwSpawn;
    public GameObject[] Clouds;
    public Transform[] locations;
    public Transform parent;

    // Update is called once per frame
    void Update()
    {
        timeBtwSpawn -= Time.deltaTime;
        if (timeBtwSpawn <= 0)
        {
            int randInt = Random.Range(0, Clouds.Length);
            int randLoc = Random.Range(0, locations.Length);
            Instantiate(Clouds[randInt], locations[randLoc].position, Quaternion.identity, parent);
            timeBtwSpawn = setTimeBtwSpawn;
        }
    }
}
