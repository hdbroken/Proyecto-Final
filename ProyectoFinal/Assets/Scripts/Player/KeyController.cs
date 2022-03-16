using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField]
    public GameObject _menuPause;
    
          
    void Update()
    {
        Pause();
    }


    private void Pause()
    {
        if ((_menuPause != null) && (Input.GetKeyDown(KeyCode.Escape)))
        {
            Time.timeScale = 0;
            _menuPause.SetActive(!_menuPause.activeSelf);
        }
    }

}
