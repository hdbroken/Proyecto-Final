using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionPlayer : MonoBehaviour
{
    public Scene _scene;

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("tocando enemigo");
            GameManager.instance.reintentos++;
            Kill();
        }
    }
    private void Kill()
    {
        SceneManager.LoadScene(_scene.name);
    }    
}