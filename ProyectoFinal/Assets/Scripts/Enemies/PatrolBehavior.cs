using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10;
    [SerializeField] float speed = 10; 
    Vector3 actualY;
    Vector3 newY;
    bool newData = false;
    bool proceed = false;
    void Update()
    {
        move();
        boton();
        Turn90();
    }
    void move()
    {
        if (!proceed)
        { 
            transform.Translate(Vector3.forward * Time.deltaTime * speed); 
        }
    }
    void boton()
    {
        if (Input.GetKey("y"))
        {
            proceed = true;
        }
    }
    void Turn90()
    {
        if (proceed)
        {
            if (newData == false)
            {
                actualY = transform.eulerAngles;

                if (actualY.y == 270)
                {
                    newY = actualY + new Vector3(0, 89, 0);
                }
                else
                {
                    newY = actualY + new Vector3(0, 90, 0);
                }
                newData = true;
            }
            if (transform.eulerAngles.y <= newY.y)
            {
                transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime), Space.Self);
                if (transform.eulerAngles.y >= 359)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    newY = new Vector3(0, 0, 0);
                    Debug.Log(transform.eulerAngles.y);
                }
            }
            if (transform.eulerAngles.y > newY.y)
            {
                transform.eulerAngles = newY;
                proceed = false;
                newData = false;
            }
        }
    }
}

