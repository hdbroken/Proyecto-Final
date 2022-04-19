using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionPlayer : MonoBehaviour
{
    
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {         
            EventManager.onPlayerDie?.Invoke();            
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LaserBullet") || other.gameObject.CompareTag("Water"))
        {            
            EventManager.onPlayerDie?.Invoke();
        }

        if (other.gameObject.CompareTag("Winning Zone"))
        {
            EventManager.onPauseGame?.Invoke(true);
            EventManager.onWinLevel?.Invoke();
        }        
    }

}