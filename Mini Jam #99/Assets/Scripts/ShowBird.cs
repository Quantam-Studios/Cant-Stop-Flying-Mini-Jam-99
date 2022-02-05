using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBird : MonoBehaviour
{
    public float setTimeToFlip;
    private float timeToFlip;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        timeToFlip = setTimeToFlip;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timeToFlip -= Time.deltaTime;

        if (timeToFlip <= 0)
        {
            int randFlip = Random.Range(0, 2);
            if (randFlip == 1)
            {
                if(sr.flipX == true)
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                else
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            timeToFlip = setTimeToFlip;
        }
    }
}
