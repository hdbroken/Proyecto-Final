using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] Quaternion angulo = Quaternion.Euler(10, 0, 0f);
    float timer;
    bool timeUp;

    void Update()
    {
        Patrol();
        checkTurn();
        timer =timer+ Time.deltaTime;
        Debug.Log("hola" + timer);
    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void checkTurn()
    {
        if (Input.GetKey("y"))
        {
            if (timer > 1)
            {
                timeUp = true;
                timer = 0;
            }
            else
            {
                timeUp = false;
            }

            if (timeUp)
            {
                transform.rotation = Quaternion.AngleAxis(90, Vector3.up) * transform.rotation;
            }
        }
    }

}
