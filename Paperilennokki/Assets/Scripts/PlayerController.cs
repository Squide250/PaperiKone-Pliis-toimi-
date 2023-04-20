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
    public float rollConstant;

    public float sprintSpeed;

    public float speed;

    //public ParticleSystem speedParticles;   

    void Start()
    {
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

        transform.Translate(0, 0, speed);

        float rollAngle = roll * responsiveness * rollConstant;
        float pitchAngle = pitch * responsiveness;


        //Vector3 targetRotation = new Vector3(pitchAngle, 0, rollAngle);

        //transform.Rotate(Vector3.Lerp(transform.rotation.eulerAngles, targetRotation, rotationSmoothness));


        //Vector3 pitchAngleSmoothed = Vector3.Lerp(currentPitch, new Vector3(pitchAngle, 0 , 0), rotationSmoothness);
        //Vector3 rollAngleSmoothed = Vector3.Lerp(currentPitch, new Vector3(0, 0, rollAngle), rotationSmoothness);

        transform.Rotate(Vector3.forward, rollAngle);
        transform.Rotate(Vector3.right, pitchAngle);
    }
}
