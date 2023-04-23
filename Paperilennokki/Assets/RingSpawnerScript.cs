using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpawnerScript : MonoBehaviour
{

    public GameObject redRingPrefab;
    public GameObject GreenRingPrefab;
    public GameObject YellowRingPrefab;

    public float maxHeight;
    public float maxRange;

    public float spawnDelay;
    


    void Start()
    {
        StartCoroutine(SpawnRing("red"));
        StartCoroutine(SpawnRing("yellow"));
        StartCoroutine(SpawnRing("green"));

        StartCoroutine(SpawnRing("red"));
        StartCoroutine(SpawnRing("yellow"));
        StartCoroutine(SpawnRing("green"));

        StartCoroutine(SpawnRing("red"));
        StartCoroutine(SpawnRing("yellow"));
        StartCoroutine(SpawnRing("green"));
    }


    //void SpawnRing(string color)
    //{
    //    GameObject finalObj = null;

    //    if (color == "red")
    //    {
    //        finalObj = redRingPrefab;
    //    }

    //    else if (color == "yellow")
    //    {
    //        finalObj = YellowRingPrefab;
    //    }

    //    else if (color == "green")
    //    {
    //        finalObj = GreenRingPrefab;
    //    }


    //    GameObject instantiated = Instantiate(finalObj);

    //    instantiated.transform.position = new Vector3(Random.Range(0f, maxRange), 0f, Random.Range(0f, maxRange));
        
    //}


    IEnumerator SpawnRing(string color)
    {
        GameObject finalObj = null;

        if (color == "red")
        {
            finalObj = redRingPrefab;
        }

        else if (color == "yellow")
        {
            finalObj = YellowRingPrefab;
        }

        else if (color == "green")
        {
            finalObj = GreenRingPrefab;
        }

        while (true)
        {
            GameObject instantiated = Instantiate(finalObj);

            instantiated.transform.position = new Vector3(Random.Range(-maxRange, maxRange), Random.Range(24f, 150f), Random.Range(-maxRange, maxRange));

            yield return new WaitForSeconds(spawnDelay);
            Destroy(instantiated);
        }
    }
}
