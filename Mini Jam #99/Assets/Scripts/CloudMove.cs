using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        float newX = (transform.position.x - (float)(0.5 * Time.deltaTime));
        transform.position = new Vector3(newX, transform.position.y, 10);
    }
}
