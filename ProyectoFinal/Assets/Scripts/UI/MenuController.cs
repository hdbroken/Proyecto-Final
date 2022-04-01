using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private string _nameInitialScene = "Level1";

    [SerializeField]
    private GameObject _animationStartGame = null;
    
   
    public void Play()
    {
        _animationStartGame.SetActive(!_animationStartGame.activeSelf);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _animationStartGame.SetActive(!_animationStartGame.activeSelf);
            SceneManager.LoadScene(_nameInitialScene);
        }
    }

    public void Exit()
    {
        Application.Quit();        
    }
    public void Help()
    {

    }

    public void Resume()
    {
        EventManager.onPauseGameWithMenu?.Invoke(false);
    }

    public void Options()
    {

    }
    public void Credits()
    {
     
    }
}
