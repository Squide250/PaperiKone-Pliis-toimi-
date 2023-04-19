using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MaxSpeed;
    Rigidbody rb;
    float roll;
    float pitch;
    public float responsiveness;
    float lift;
    public float rollConstant;

    public float maxFlightTime;
    float flightTime;

    public float flightTimePercentage;

    public float sprintSpeed;

    public float speed;

    //public ParticleSystem speedParticles;   

    void Start()
    {

        flightTime = maxFlightTime;

        speed = MaxSpeed;

        rb = GetComponent<Rigidbody>();
    }

    void GetInputs()
    {
        roll = -Input.GetAxis("Horizontal");
        pitch = -Input.GetAxis("Vertical");
    }

    void Update()
    {

        //var emission = speedParticles.emission;
        //emission.rateOverTime = ((speed - MaxSpeed)/(sprintSpeed-MaxSpeed)+0.1f) * 100f;

        if(flightTime > 0)
        {
            flightTime -= Time.deltaTime;
        }

        flightTimePercentage = flightTime / maxFlightTime;

        //speed = MaxSpeed * flightTimePercentage;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }

        GetInputs();

        if (speed > MaxSpeed)
        {
            speed -= 0.1f * Time.deltaTime;
        }
        if (speed < MaxSpeed)
        {
            speed = MaxSpeed;
        }
    }

    private void FixedUpdate()
    {

        //rb.AddForce(Vector3.up * 9.81f * (0.75f + flightTimePercentage/4));


        transform.Translate(0, 0, speed);

        //rb.AddRelativeForce(0, 0, speed * 100);


        rb.AddTorque(transform.forward * roll * responsiveness * rollConstant);
        rb.AddTorque(transform.right * pitch * responsiveness);

    }
}
