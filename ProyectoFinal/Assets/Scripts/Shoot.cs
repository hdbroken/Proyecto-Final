using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private LineRenderer laser;

    private void Awake()
    {
        laser = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    public void Shooting(Camera player)
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            laser.SetPosition(0, player.transform.position);
            laser.SetPosition(1, player.transform.forward * 1000);

            RaycastHit hit;
            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit))
            {
                if (hit.collider)
                {
                    laser.SetPosition(1, hit.point);
                }
            }
            else
            {
                laser.SetPosition(1, player.transform.position * 1000);
            }
        }
        else
        {
            laser.SetPosition(0, player.transform.position);
            laser.SetPosition(1, player.transform.position);
        }
    }
}
