using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DetectEnemy : MonoBehaviour
{
    

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("ENEMY"))
        {
            Debug.Log("tocando enemigo");
            GameManager.instance.reintentos++;
            GameManager.instance.kill();           
        }
    }

}