using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject _menu;

    [SerializeField]
    private GameObject _hud;

    [SerializeField]
    private GameObject _player;

    private Scene _scene;

    private void OnEnable()
    {
        EventManager.onPauseGame += OnGamePauseEvent;
        EventManager.onPauseGameWithMenu += OnGamePauseWithMenuEvent;
        EventManager.onPlayerDie += OnPlayerDieEvent;
      //  EventManager.onWinLevel += OnWinLevelEvent;
    }

    private void OnDisable()
    {
        EventManager.onPauseGame -= OnGamePauseEvent;
        EventManager.onPauseGameWithMenu -= OnGamePauseWithMenuEvent;
        EventManager.onPlayerDie -= OnPlayerDieEvent;
       // EventManager.onWinLevel -= OnWinLevelEvent;
    }

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }

    private void OnGamePauseEvent(bool isPausedGame)
    {
        if (isPausedGame == true)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;        
    }

    private void OnGamePauseWithMenuEvent(bool isPausedGame)
    {
        EventManager.onPauseGame?.Invoke(isPausedGame);

        _menu.SetActive(isPausedGame);
    }

    private void OnPlayerDieEvent()
    {
        SceneManager.LoadScene(_scene.name);
    }


}
