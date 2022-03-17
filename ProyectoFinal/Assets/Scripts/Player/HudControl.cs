using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudControl : MonoBehaviour
{
    [SerializeField] GameObject hud;
    void Start()
    {
        //hud.SetActive(false);
    }

    void Update()
    {
        Aim();
    }

    void Aim() 
    {
        if (Input.GetKey(KeyCode.Mouse1)) 
        {
        hud.SetActive(true);
            
        }
        else 
        {
            hud.SetActive(false);
        }
    
    }
}
