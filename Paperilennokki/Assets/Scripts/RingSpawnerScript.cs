using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RingSpawnerScript : MonoBehaviour
{

    public GameObject redRingPrefab;
    public GameObject GreenRingPrefab;
    public GameObject YellowRingPrefab;

    public int numberOfRings;

    GameObject finalObj;

    public float maxHeight;
    public float maxRange;

    public float spawnDelay;
    


    void Start()
    {
        for(int i = 0; i < numberOfRings; i++)
        {
            SpawnRing("red");
            SpawnRing("green");
            SpawnRing("yellow");
        }
    }


    public void SpawnRing(string color)
    {


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

        GameObject instantiated = Instantiate(finalObj);
        instantiated.transform.position = new Vector3(Random.Range(-maxRange, maxRange), Random.Range(24f, 150f), Random.Range(-maxRange, maxRange));
        instantiated.transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);

        TextMeshProUGUI textObject = new GameObject().AddComponent<TextMeshProUGUI>();
        textObject.transform.SetParent(instantiated.transform);
        textObject.text = "I HATE NIGHTMARES";
        textObject.rectTransform.localPosition = Vector3.zero;
    }
}
