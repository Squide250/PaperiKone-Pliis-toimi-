using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderScript : MonoBehaviour
{

    public PlayerController playerController;
    public Slider flightTimeSlider;


    void Update()
    {
        flightTimeSlider.value = playerController.flightTimePercentage; 
    }
}
