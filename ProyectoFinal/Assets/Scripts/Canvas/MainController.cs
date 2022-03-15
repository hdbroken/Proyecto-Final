using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;

public class MainController : MonoBehaviour
{
    [SerializeField]
    private string _nameInitialScene = "Level1";
    /*[SerializeField]
    private Button _play;
    [SerializeField]
    private Button _exit;
    [SerializeField]
    private Button _options;
    [SerializeField]
    private Button _credits;

    [SerializeField]
    private Button _resume;
    [SerializeField]
    private Button _help;*/
    

    /*private void OnEnable()
    {
        _play.onClick.AddListener(Play);
        _exit.onClick.AddListener(Exit);
        _options.onClick.AddListener(Options);
        _credits.onClick.AddListener(Credits);
        _resume.onClick.AddListener(Resume);
        _help.onClick.AddListener(Help);
    }
    

    private void OnDisable()
    {
        _play.onClick.RemoveListener(Play);
        _exit.onClick.RemoveListener(Exit);
        _options.onClick.RemoveListener(Options);
        _credits.onClick.RemoveListener(Credits);
        _resume.onClick.RemoveListener(Resume);
        _help.onClick.RemoveListener(Help);
    }*/
   
    public void Play()
    {
        SceneManager.LoadScene(_nameInitialScene);
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego");
    }
    public void Help()
    {

    }

    public void Resume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void Options()
    {

    }
    public void Credits()
    {
     
    }
}
