using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textSuccess;

    [SerializeField]
    private GameObject _sightAndWeaponHUD;

    private void Awake()
    {
       // EventManager.onClickAimButtonEvent += OnAimEvent;
        EventManager.onWinLevel += OnWinLevelEvent;        
    }

    private void OnDestroy()
    {
        //EventManager.onPauseGame -= OnMenuPauseEvent;
        EventManager.onWinLevel -= OnWinLevelEvent;
    }


    public void OnAimEvent(bool isPaused)
    {
        _sightAndWeaponHUD.SetActive(isPaused);        
    }
    
    private void OnWinLevelEvent()
    {
        _textSuccess.gameObject.SetActive(true);
    }
}
