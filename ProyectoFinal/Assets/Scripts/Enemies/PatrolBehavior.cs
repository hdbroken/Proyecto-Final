using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10;
    Vector3 actualY;
    Vector3 newY;
    bool newData = false;
    bool fix = false;
    void Update()
    {
        Turn90();
    }
    void Turn90()
    {
        if (transform.eulerAngles == new Vector3(0, 270, 0))
        {
            if (newData == false)
            {
                actualY = transform.eulerAngles;
                newY = new Vector3(0, 0, 0);
                newData = true;
            }
            if (transform.eulerAngles.y >= newY.y)
            {
                transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime), Space.Self);
            }
            /*if (transform.eulerAngles.y < newY.y)
            {
                fix = true;
            }
            if (fix)
            {
                transform.eulerAngles = newY;
                fix = false;
            }*/
        }
        else
        {
            if (newData == false)
            {
                actualY = transform.eulerAngles;
                newY = actualY + new Vector3(0, 90, 0);
                newData = true;
            }
            if (transform.eulerAngles.y <= newY.y)
            {
                transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime), Space.Self);
            }
            if (transform.eulerAngles.y > newY.y)
            {
                fix = true;
            }
            if (fix)
            {
                transform.eulerAngles = newY;
                fix = false;
            }
        }
    }
}
