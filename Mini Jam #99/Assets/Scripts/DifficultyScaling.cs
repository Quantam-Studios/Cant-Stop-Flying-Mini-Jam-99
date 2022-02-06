using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScaling : MonoBehaviour
{
    public ObstacleSpawner obstSpawner;
    public Player playerScript;
    public GameObject player;
    public bool passedDist1;
    public bool passedDist2;
    public bool passedDist3;
    public bool passedDist4;
    public int distance1;
    public int distance2;
    public int distance3;
    public int distance4;
    public int playerXPos;
    public float defaultTimeBtwSpawn;

    private void Start()
    {
        obstSpawner.setTimeBtwSpawn = defaultTimeBtwSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        playerXPos = (int)(player.transform.position.x - 61.425f);
        if (playerXPos >= distance1 && !passedDist1)
        {
            playerScript.speed += 2;
            passedDist1 = true;
        }

        if (playerXPos >= distance2 && !passedDist2)
        {
            passedDist2 = true;
            playerScript.speed += 2;
            obstSpawner.setTimeBtwSpawn -= 0.35f;
        }

        if (playerXPos >= distance3 && !passedDist3)
        {
            passedDist3 = true;
            playerScript.speed += 0.25f;
            obstSpawner.setTimeBtwSpawn -= 0.5f;
        }

        if (playerXPos >= distance4 && !passedDist4)
        {
            passedDist4 = true;
            playerScript.speed += 0.25f;
        }
    }

    public void ResetDifficulty()
    {
        playerScript.speed = playerScript.setSpeed;
        obstSpawner.setTimeBtwSpawn = defaultTimeBtwSpawn;
        passedDist1 = false;
        passedDist2 = false;
        passedDist3 = false;
    }
}
