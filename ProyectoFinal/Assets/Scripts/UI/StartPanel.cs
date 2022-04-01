using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartPanel : MonoBehaviour
{
    [SerializeField]
    private string _commandLine1;
    [SerializeField]
    private string _commandLine2;

    [SerializeField]
    private GameObject _textStart;
    [SerializeField]
    private GameObject _textLoading;
    [SerializeField]
    private GameObject _textPressEnter;


    private TextMeshProUGUI _textcommandLine1;

    private TextMeshProUGUI _textcommandLine2;

    private int _length = 0;
    private int _length2 = 0;

    private float _timer = 0;
    private float _timeToWrite = 0;

    private int _index = 0;
    private int _index2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        _textcommandLine1 = _textStart.GetComponent<TextMeshProUGUI>();
        _length = _commandLine1.Length;
        _length2 = _commandLine2.Length;
        _timer = 0;
        _timeToWrite = Random.Range(0.1f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;


        if (_index < _length)
        {
            if (_timer >= _timeToWrite)
            {
                _timer = 0;
                if (_commandLine1[_index] == '+')
                {
                    _textcommandLine1.text += '\n';
                }
                else
                {
                    _textcommandLine1.text += _commandLine1[_index];
                    _timeToWrite = Random.Range(0.1f, 0.5f);
                }
                _index++;
            }
        }
        else
        {
            if (!_textLoading.activeSelf)
            {
                _textLoading.SetActive(true);
                _textcommandLine2 = _textLoading.GetComponent<TextMeshProUGUI>();
            }
            if (_index2 < _length2)
            {
                if (_timer > 1)
                {
                    _timer = 0;
                    _textcommandLine2.text += _commandLine2[_index2];
                    _index2++;
                }
            }
            else
            {
                if (!_textPressEnter.activeSelf)
                {
                    _textPressEnter.SetActive(true); 
                }
            }
        }


    }
}
