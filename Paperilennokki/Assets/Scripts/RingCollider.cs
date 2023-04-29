using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingCollider : MonoBehaviour
{
    public RingScript ringScript;

    Collider col;

    private void Start()
    {
        col = gameObject.GetComponent<MeshCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        col.enabled = false;
        ringScript.RingCollision();
    }

}
