using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeStart;
    [SerializeField] private float _time;
    [SerializeField] private TMP_Text _timerText;

    public void PressKey(bool press)
    {
        if (press)
        {
            _time = _timeStart;
        }        
    }

    public bool SPWR()
    {
        if (_timerText.text == ("Ok"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Update()
    {        
            OnTimeRestart();
    }
    private void OnTimeRestart()
    {
        if (_time <= 0)
        {
            _timerText.color = new Color(0, 255, 0);
            _timerText.text = ("Ok");

        }
        else
        {
            _timerText.color = new Color(255, 0, 0);
            _time -= Time.deltaTime;
            _timerText.text = Mathf.Round(_time).ToString();
        }
    }

    public void Restart()
    {
        _time = _timeStart;
    }
   
   





}
