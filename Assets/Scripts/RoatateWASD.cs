using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class RoatateWASD : MonoBehaviour
{

    [SerializeField]
    public float rot_speed = 40.0f;
    [SerializeField]
    float rot_max = 40.0f;
  

    Vector3 rot_vector = new Vector3 (0, 0, 1);
    float currentRotationZ;
    bool left_enable = true;
    bool right_enable = true;
    // Update is called once per frame
    void Update()
    {
        currentRotationZ = transform.rotation.eulerAngles.z;

        //check if max rotation reached
        if (currentRotationZ > rot_max && currentRotationZ < 360 - rot_max) { left_enable = false; right_enable = true; }
        else { left_enable = true; }
                                                                  // safety net for overshooting
        if (currentRotationZ < 360 - rot_max && currentRotationZ > rot_max +2) { right_enable = false; left_enable = true; }
        else { right_enable = true; }

            // roatate left
            if (Input.GetKey(KeyCode.A) && left_enable)
            {
                transform.Rotate(rot_vector, rot_speed * Time.deltaTime);
            }
            // rotate right
            if (Input.GetKey(KeyCode.D) && right_enable)
            {
                transform.Rotate(rot_vector, -rot_speed * Time.deltaTime);
            }


    }
}
