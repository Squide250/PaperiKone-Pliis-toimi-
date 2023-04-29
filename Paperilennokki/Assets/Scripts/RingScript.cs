using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScript : MonoBehaviour
{

    PointScript pointScript;
    RingSpawnerScript ringSpawnerScript;
    public float lifeTime;

    private void Awake()
    {
        pointScript = GameObject.Find("Player").GetComponent<PointScript>();
        ringSpawnerScript = GameObject.Find("RingSpawner").GetComponent<RingSpawnerScript>();

        StartCoroutine(death());
    }

    public void RingCollision()
    {

        if (CompareTag("green"))
        {
            pointScript.ringToCoroutine("green");

        }
        if (CompareTag("yellow"))
        {
            pointScript.ringToCoroutine("yellow");

        }
        if (CompareTag("red"))
        {
            pointScript.ringToCoroutine("red");
        }

        ringSpawnerScript.SpawnRing(tag);

        Destroy(gameObject);
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(lifeTime);
        ringSpawnerScript.SpawnRing(tag);
        Destroy(gameObject);
    }

}
