using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolShoot : MonoBehaviour
{

    [SerializeField] float speed = 5;
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

}


