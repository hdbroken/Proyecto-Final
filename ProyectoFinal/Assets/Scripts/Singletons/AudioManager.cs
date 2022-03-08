using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    void Awake()
    {
        int countAM = FindObjectsOfType<AudioManager>().Length;

        if(countAM > 1) 
        {
            Destroy(gameObject);
        }
        else  
        {        
            DontDestroyOnLoad(gameObject);
        }


    }

   
}
