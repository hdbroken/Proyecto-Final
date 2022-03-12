using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float timeToTurn = 10;
    [SerializeField] float rotationSpeed = 10;
    float timer;
    bool timeUp;
    //deben tomar una unica vez los datos por cada rotacion de 90 grados
    //https://docs.unity3d.com/ScriptReference/Mathf.LerpAngle.html
    Vector3 actualY;
    Vector3 newY;
    bool newData = false; 

        Vector3 lol;

    void Update()
    {
        timer = timer + Time.deltaTime;
        Turn90();
        //Move();
    }

    void Turn90()
    {
        if (newData == false)
        {
            Debug.Log("solo debo ver este cartel una vez");
            actualY = transform.eulerAngles;
            newY = actualY + new Vector3(0, 90, 0);
            newData = true;
        }
        Debug.Log("esta es la posicion inicial y no tiene que cambiar" + actualY);
        Debug.Log("esta es la posicion final y no tiene que cambiar" + newY);

        if (lol != newY)
        {
            Debug.Log(" transform es " +transform.eulerAngles);
            transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));

            Vector3 lol = new Vector3(Mathf.Round(transform.eulerAngles.x), Mathf.Round(transform.eulerAngles.y),Mathf.Round(transform.eulerAngles.z) );

            Debug.Log("lol es " +lol);
        }
    } 

    /*void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        
        if(timeToTurn > timer) 
        {
            transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
        }
    }*/




}
