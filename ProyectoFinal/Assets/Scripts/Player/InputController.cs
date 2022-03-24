using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private GameObject _menu;

    [SerializeField]
    private UnityEvent onClickAimButtonEvent;

    [SerializeField]
    private UnityEvent onUnClickAimButtonEvent;

    void Update()
    {
        Pause();
        Aim();
    }


    private void Pause()
    {
        if ((_menu != null) && (Input.GetKeyDown(KeyCode.Escape)))
        {
            EventManager.onPauseGameWithMenu.Invoke(!_menu.activeSelf);            
        }
    }

    private void Aim()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
           onClickAimButtonEvent?.Invoke();
        }
        else if(Input.GetKeyUp(KeyCode.Mouse1))
        {
           onUnClickAimButtonEvent?.Invoke();
        }
    }
}
