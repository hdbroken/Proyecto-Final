using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testpause : MonoBehaviour
{

    [SerializeField]
    private GameObject _menuPause;

    // Update is called once per frame
    void Update()
    {
    if(Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            _menuPause.SetActive(!_menuPause.activeSelf);
        }
    }
}
