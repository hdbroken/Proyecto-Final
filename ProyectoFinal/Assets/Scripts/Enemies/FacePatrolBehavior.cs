using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePatrolBehavior : MonoBehaviour
{
    [SerializeField] GameObject bean;  

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
             Instantiate(bean, transform.position, transform.rotation);        
        }

    }

    public void shoot() 
    {
        Instantiate(bean, transform.position, transform.rotation); 
    }

      
}
