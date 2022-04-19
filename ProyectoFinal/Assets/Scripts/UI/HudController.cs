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
    private GameObject _triesHud;

    private TextMeshProUGUI _displayTries;

    private void Awake()
    {
        EventManager.onWinLevel += OnWinLevelEvent;
        _displayTries = _triesHud.GetComponentInChildren<TextMeshProUGUI>();
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
        _triesHud.SetActive(!_triesHud.activeSelf);
        _displayTries.text = ("Tries: " + GameManager.instance.tries);
    }

    private void OnWinLevelEvent()
    {
        _textSuccess.gameObject.SetActive(true);
    }
}
