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

    public Transform canvas;


    private void Start()
    {
        points = 0f;

        scoreText.text = "SCORE: " + points.ToString();
        scoreTextShadow.text = "SCORE: " + points.ToString();
    }

    public void ringToCoroutine(string color)
    {
        if (color == "green")
        {
            StartCoroutine(AddScore(50f));
            StartCoroutine(InstantiatePoints("green"));

        }
        if (color == "yellow")
        {
            StartCoroutine(AddScore(100f));
            StartCoroutine(InstantiatePoints("yellow"));

        }
        if (color == "red")
        {
            StartCoroutine(AddScore(200f));
            StartCoroutine(InstantiatePoints("red"));
        }
    }

    public IEnumerator AddScore(float score)
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

    public IEnumerator InstantiatePoints(string color)
    {
        GameObject instantiated = null;

        if (color == "green")
        {
            instantiated = Instantiate(addGreenScore, canvas);
        }
        else if (color == "yellow")
        {
            instantiated =  Instantiate(addYellowScore, canvas);
        }
        else if (color == "red")
        {
            instantiated = Instantiate(addRedScore, canvas);
        }

        for (int i = 0; i < 100; i++)
        {
            instantiated.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
            yield return new WaitForSeconds(0.05f);

            if(i == 100 || instantiated.transform.localScale.x <= 0f)
            {
                Destroy(instantiated);
                yield return null;
                break;
            }
        }
    }

}
