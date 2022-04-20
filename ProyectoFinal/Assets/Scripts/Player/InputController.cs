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

    [SerializeField]
    private UnityEvent onPressKeyHudEvent;

    void Update()
    {
        Pause();
        Aim();
        Hud();
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

    private void Hud()
    {
        if (Input.GetKeyDown(KeyCode.H) || (!GameManager.instance.playerIsAlive))
        {
            onPressKeyHudEvent?.Invoke();
        }
    }
}
