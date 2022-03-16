using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] float speed = 5;
    void Start()
    {

    }
    void Update()
    {
        transform.position = transform.position + new Vector3(0, 0, 1) * Time.deltaTime * speed;
    }

}
