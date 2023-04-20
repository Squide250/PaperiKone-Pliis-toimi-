using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointScript : MonoBehaviour
{
    public float pointIncrement;

    public float points;
    float desiredPoints;
    public TextMeshProUGUI scoreNum;


    private void Start()
    {
        points = 0f;

        scoreNum.text = points.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.tag == "Ring")
        {
            StartCoroutine(AddScore());
        }


    }

    IEnumerator AddScore()
    {
        desiredPoints += 100f;

        while (points < desiredPoints)
        {
            points += pointIncrement;
            if(points > desiredPoints)
            {
                points -= (points - desiredPoints);
            }

            scoreNum.text = points.ToString();
            yield return new WaitForEndOfFrame();
        }
    }



}
