using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolShoot : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] float disappear = 10;
    private float timer;
    private float xyz=1;

    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        Remove();
        Debug.Log(timer);
    }

    void Remove() 
    {
        if (timer>=(disappear-2))
        {
            transform.localScale= new Vector3(xyz,xyz,xyz);
            xyz-=(0.5f*Time.deltaTime);            
        }

        if (timer>=disappear)
        {
            transform.localScale= new Vector3(timer,timer,timer);
            xyz=0;
            timer=0;
            Destroy(gameObject);
        }
    }





}


