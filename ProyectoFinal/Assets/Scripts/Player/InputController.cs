using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private GameObject _menu;

    [SerializeField]
    public UnityEvent<bool> onClickAimButtonEvent;


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

    void Aim()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            
            //EventManagerUnity.onClickAimButtonEvent?.Invoke(true);
        }
        else if(Input.GetKeyUp(KeyCode.Mouse1))
        {
          //  EventManagerUnity.onClickAimButtonEvent?.Invoke(false);
        }

    }

}
