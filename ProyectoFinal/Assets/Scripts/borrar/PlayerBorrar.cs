using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBorrar : MonoBehaviour
{


    [SerializeField] Vector3 Rotacion = new Vector3(0f, 180f, 0f);
    [SerializeField] Vector3 Position = new Vector3(0f, 0f, 0f);
    [SerializeField] float Speed = 5f;
     public Vector3 direccion;

    void Start()
    {
        StartPos();
    }

    void Update()
    {
        Move();
    }

    void StartPos()
    {
        transform.Rotate(Rotacion);
        transform.localPosition = Position;
    }

    void Move() 
    {
         direccion = Vector3.zero;
        if (Input.GetKey("w")) { direccion = Vector3.forward; };
        if (Input.GetKey("a")) { direccion = Vector3.left; };
        if (Input.GetKey("s")) { direccion = Vector3.back; };
        if (Input.GetKey("d")) { direccion = Vector3.right; };
        Debug.Log(transform.position);
        
        transform.position = transform.position + direccion * Time.deltaTime * (Speed * 3);
        
    }

}
