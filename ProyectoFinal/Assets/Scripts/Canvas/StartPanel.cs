using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartPanel : MonoBehaviour
{
    [SerializeField]
    private string _message;

    private int _length = 0;

    private TextMeshProUGUI _text;

    private float _timer = 0;

    private int _index = 1;

    // Start is called before the first frame update
    void Start()
    {
        _length = _message.Length;
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_index < _length)
        {
            _timer += Time.deltaTime;
            float _timeToWrite = Random.Range(0.1f, 0.4f);

            if (_timer >= _timeToWrite)
            {
                _timer = 0;
                if (_message[_index] == '+')
                {
                    _text.text += '\n';
                }
                else
                {
                    _text.text += _message[_index];
                }
                _index++;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape)) Destroy(this);
        }
    }
}
