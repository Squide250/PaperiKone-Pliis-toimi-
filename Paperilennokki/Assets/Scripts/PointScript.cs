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
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextShadow;
    public float scoreDelay;

    public GameObject addYellowScore;
    public GameObject addGreenScore;
    public GameObject addRedScore;


    private void Start()
    {
        points = 0f;

        scoreText.text = "SCORE: " + points.ToString();
        scoreTextShadow.text = "SCORE: " + points.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.tag == "GreenRing")
        {
            StartCoroutine(AddScore(50f));
            Instantiate(addGreenScore);
        }
        if (other.tag == "YellowRing")
        {
            StartCoroutine(AddScore(100f));
        }
        if (other.tag == "RedRing")
        {
            StartCoroutine(AddScore(200f));
        }
    }

    IEnumerator AddScore(float score)
    {
        desiredPoints += score;

        while (points < desiredPoints)
        {
            points += pointIncrement;
            if(points > desiredPoints)
            {
                points -= (points - desiredPoints);
            }

            scoreText.text = "SCORE: " + points.ToString();
            scoreTextShadow.text = "SCORE: " + points.ToString();
            yield return new WaitForSeconds(scoreDelay);
        }
    }



}
