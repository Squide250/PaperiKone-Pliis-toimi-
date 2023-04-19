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

    public float speed;

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
        if(flightTime > 0)
        {
            flightTime -= Time.deltaTime;
        }

        flightTimePercentage = flightTime / maxFlightTime;

        speed = MaxSpeed * flightTimePercentage;

        GetInputs();
    }

    private void FixedUpdate()
    {

        rb.AddForce(Vector3.up * 9.81f * (0.75f + flightTimePercentage/4));


        transform.Translate(0, 0, speed);

        //rb.AddRelativeForce(0, 0, speed * 100);


        //rotation
        rb.AddTorque(transform.forward * roll * responsiveness * rollConstant);
        rb.AddTorque(transform.right * pitch * responsiveness);

    }
}
