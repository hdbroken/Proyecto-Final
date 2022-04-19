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

    [SerializeField]
    private GlobalPPController _globalVolume;

    private Scene _scene;
    private Vector3 _initialPosition;
    private float _initialRotationDegrees;
    private FirstPersonCC _moveController;    

    private void OnEnable()
    {
        EventManager.onPauseGame += OnGamePauseEvent;
        EventManager.onPauseGameWithMenu += OnGamePauseWithMenuEvent;
        EventManager.onPlayerDie += OnPlayerDieEvent;      
    }

    private void OnDisable()
    {
        EventManager.onPauseGame -= OnGamePauseEvent;
        EventManager.onPauseGameWithMenu -= OnGamePauseWithMenuEvent;
        EventManager.onPlayerDie -= OnPlayerDieEvent;       
    }

    private void Awake()
    {        
        _moveController = _player.GetComponent<FirstPersonCC>();
        _scene = SceneManager.GetActiveScene();
        
        _initialPosition = _player.transform.position;
        _initialRotationDegrees = _player.transform.rotation.eulerAngles.y;        
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

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(_scene.name);
        GameManager.instance.playerIsAlive = true;
    }

    IEnumerator ToDie()
    {        
        _moveController.StopMove(true);
        _moveController.LookOnDeath();        

        _globalVolume.Death();

        yield return new WaitForSeconds(5f);

        InitialPosition();

        _globalVolume.Alive();
        GameManager.instance.playerIsAlive = true;
        _moveController.StopMove(false);        
    }
    private void OnPlayerDieEvent()
    {
        GameManager.instance.tries += 1;
        GameManager.instance.playerIsAlive = false;
        
        StartCoroutine(ToDie());
        //StartCoroutine(ReloadScene());        
    }

    public void InitialPosition()
    {
        _player.transform.position = _initialPosition;
        _moveController.hMouse = _initialRotationDegrees;
        _moveController.vMouse = 0;
    }
}
