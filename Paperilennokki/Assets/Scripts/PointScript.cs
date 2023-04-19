using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if( other.tag == "Halo")
        {
            print("entered a Halo");
        }
    }

}
