using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailHolder : MonoBehaviour
{
    public int maxParticles;

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > maxParticles)
        {
            int particlesToDestroy = transform.childCount - maxParticles;
            for (int i = 0; i < particlesToDestroy; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
