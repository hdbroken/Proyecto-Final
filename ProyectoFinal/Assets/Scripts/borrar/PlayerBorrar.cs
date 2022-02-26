using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBorrar : MonoBehaviour
{
    [SerializeField] Vector3 StartingRotation = new Vector3(0f, 180f, 0f);
    [SerializeField] Vector3 StartingPosition = new Vector3(0f, 0f, 0f);
    [SerializeField] float PlayerSpeed = 5f;
    //[SerializeField] float sensibility = 1f;
    private LineRenderer laser;
    private float cameraX;
    private float cameraY;
    private Vector3 direccion;

    void Start()
    {
        StartPos();
        laser = GetComponent<LineRenderer>();
    }
    void Update()
    {
        Move();
        Rotate();
        Shoot();
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
        Quaternion angulo = Quaternion.Euler(cameraX, cameraY, 0f);
        transform.localRotation = angulo;
    }

    void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("piw piu");
            laser.SetPosition(0, transform.position);
            laser.SetPosition(1, transform.forward * 1000);
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward*1000, out hit))
            {
                if (hit.collider == null)
                {
                    laser.SetPosition(1, hit.point);
                }
            }
            else
            {
                laser.SetPosition(1, transform.forward * 1000);
            }

        }
        else
        {
            Debug.Log("piw piu");
            laser.SetPosition(0, transform.position);
            laser.SetPosition(1, transform.position);

        }
    }
}
