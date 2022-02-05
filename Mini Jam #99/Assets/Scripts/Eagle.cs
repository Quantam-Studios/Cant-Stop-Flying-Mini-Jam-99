using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        float newX = (transform.position.x + speed * Time.deltaTime);
        transform.position = new Vector3(newX, transform.position.y, 0);
    }
}
