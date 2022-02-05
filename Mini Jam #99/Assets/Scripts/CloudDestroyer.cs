using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDestroyer : MonoBehaviour
{
    public GameObject obstHolder;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.transform.parent != null && !GameObject.ReferenceEquals(col.gameObject.transform.parent.gameObject, obstHolder))
        {
            Destroy(col.gameObject.transform.parent.gameObject);
        }
        Destroy(col.gameObject);
    }
}
