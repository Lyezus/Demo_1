using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Left_and_Right : MonoBehaviour
{
    [Tooltip("Roatton arc in degrees")][SerializeField] float arc = 30f;
    [SerializeField] float rotationSpeed = 10f;

    bool moveLeft, moveRight;
    float leftLimit, rightLimit, leftGrace , rightGrace;
    float currentRotation;
    // Start is called before the first frame update
    void Start()
    {
        leftLimit = arc / 2;
        rightLimit = 360 - arc / 2;
        leftGrace = leftLimit + 2;
        rightGrace = rightLimit - 2;
        //roataton starts  left by default
        moveLeft = true;
        moveRight = false;       
    }

    // Update is called once per frame
    void Update()
    {

        currentRotation = transform.rotation.eulerAngles.z;

        if (moveLeft)   // keep rotating left
        {
            transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);
        }
        if (moveRight) // keep roatating right
        {
            transform.Rotate(-rotationSpeed * Time.deltaTime * Vector3.forward);
        }
        //enter rotation limt while moving left
        if (moveLeft && currentRotation > leftLimit  && currentRotation < rightGrace  ) { moveLeft = false; moveRight = true; }
        //enter rotation limt while moving right
        if (moveRight && currentRotation < rightLimit && currentRotation > leftGrace) { moveLeft = true; moveRight = false; }


    }
}
