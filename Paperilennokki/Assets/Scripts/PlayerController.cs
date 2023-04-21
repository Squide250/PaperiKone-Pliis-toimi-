using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MaxSpeed;
    Rigidbody rb;

    public float responsiveness;
    public float rollConstant;
    public float rollSpeed = 0.5f;
    public float pitchSpeed = 0.5f;

    //public float AngularRotationMultiplier;

    public Transform planeGraphics;

    public float inputDelay = 0.01f;
    public float inputIncrement = 0.1f;

    public float sprintSpeed;

    public float speed;

    public float roll;
    public float pitch;
    public float yaw;


    public float lerpFactor;


    //public ParticleSystem speedParticles;   

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;

        speed = MaxSpeed;

        rb = GetComponent<Rigidbody>();
    }

    void GetInputs()
    {
        //roll = -Input.GetAxis("Horizontal");
        //pitch = -Input.GetAxis("Vertical");
        //yaw = Input.GetAxis("Yaw");


        //roll = -Input.GetAxis("");
        pitch = -Input.GetAxis("Mouse Y");
        yaw = Input.GetAxis("Mouse X");

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
        float yawAngle = yaw * responsiveness;


        transform.Rotate(Vector3.forward, rollAngle);
        transform.Rotate(Vector3.right, pitchAngle);
        transform.Rotate(Vector3.up, yawAngle);

        //Quaternion graphicsRotation = planeGraphics.rotation;

        //Vector3 localAngularVelocity = transform.InverseTransformDirection(rb.angularVelocity);
        //graphicsRotation.z = localAngularVelocity.y * AngularRotationMultiplier;


        //planeGraphics.Rotate(Vector3.forward, graphicsRotation.z, Space.Self);


    }

}
