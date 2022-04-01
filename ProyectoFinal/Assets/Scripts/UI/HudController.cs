using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class HudController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textSuccess;

    [SerializeField]
    private GameObject _sightHud;

    [SerializeField]
    private GameObject _weaponHud;

    private void Awake()
    {
        EventManager.onWinLevel += OnWinLevelEvent;
    }

    private void OnDestroy()
    {
        EventManager.onWinLevel -= OnWinLevelEvent;
    }

    public void OnAimEvent(bool isPaused)
    {
        _sightHud.SetActive(isPaused);
    }

    public void OnActivateHudEvent()
    {
        _weaponHud.SetActive(!_weaponHud.activeSelf);
    }

    private void OnWinLevelEvent()
    {
        _textSuccess.gameObject.SetActive(true);
    }
}
