using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(name + "colision con " + collision.gameObject.name);
       
    }
    
}
