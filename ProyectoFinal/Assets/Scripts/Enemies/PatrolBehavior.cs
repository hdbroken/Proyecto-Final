using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    //Move
    [SerializeField] float speed = 10;
    [SerializeField] float timeToTurn = 4;
    private float timer;
    private bool proceed = false;
    //Turn Data
    [SerializeField] float rotationSpeed = 10;
    private Vector3 actualY;
    private Vector3 newY;
    private bool newData = false;
    int contador = 0;

    void Update()
    {
        timer += Time.deltaTime;
        Move();
        Boton();
        Turn90();       
    }

   /* private void OnCollisionEnter(Collision other)
    {
        Debug.Log("bb");
        contador++;
        proceed = true;
    }*/

    private void OnCollisionStay(Collision collision)
    {        
        contador++;
        proceed = true;
    }
    void Move()
    {
       // Debug.Log("el tiempo es: " + timer);
        if (!proceed)
        {
            if (timeToTurn >= timer)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            else
            {
                proceed = true;
            }
        }
    }
    
    void Boton()
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
                   // Debug.Log(transform.eulerAngles.y);
                }
            }

            if (transform.eulerAngles.y > newY.y)
            {
                transform.eulerAngles = newY;
                proceed = false;
                newData = false;
                contador++;
                if (contador >= 2)
                {
                    timer = 0;
                    contador = 0;
                }
            }
        }
    }
}

