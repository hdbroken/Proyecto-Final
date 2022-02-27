using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBorrar : MonoBehaviour
{    
    //posicion inicial
    [SerializeField] Vector3 StartingRotation = new Vector3(0f, 180f, 0f);
    [SerializeField] Vector3 StartingPosition = new Vector3(0f, 0f, 0f);
    //Movimiento   
    [SerializeField] float PlayerSpeed = 5f;
    private Vector3 direccion;
    //Camara
    private float cameraX;
    private float cameraY;
    [SerializeField] float speedCameraX = 1f;
    [SerializeField] float SpeedCameraY = 1f;
    //Laser
    private LineRenderer laser;
    private Shoot fire;

    void Start()
    {
        StartPos();
        laser = GetComponent<LineRenderer>();
        fire = GetComponent<Shoot>();
    }
    void Update()
    {
        Move();
        Rotate();
        //fire.Shooting();
    }
    void StartPos()
    {
        transform.Rotate(StartingRotation);
        transform.localPosition = StartingPosition;
    }
    void Move()
    {
        direccion = Vector3.zero;
        if (Input.GetKey("w")) { direccion = Vector3.forward; };
        if (Input.GetKey("a")) { direccion = Vector3.left; };
        if (Input.GetKey("s")) { direccion = Vector3.back; };
        if (Input.GetKey("d")) { direccion = Vector3.right; };
        transform.Translate(direccion * PlayerSpeed * Time.deltaTime);
    }
    void Rotate()
    {
        cameraY += Input.GetAxis("Mouse X");
        cameraX += (Input.GetAxis("Mouse Y") * -1);
        Quaternion angulo = Quaternion.Euler(cameraX *speedCameraX, cameraY *SpeedCameraY, 0f);
        transform.localRotation = angulo;
    }

}
