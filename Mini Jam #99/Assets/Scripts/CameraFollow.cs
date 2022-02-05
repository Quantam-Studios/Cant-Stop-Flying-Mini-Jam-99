using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        float newX = player.transform.position.x;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
