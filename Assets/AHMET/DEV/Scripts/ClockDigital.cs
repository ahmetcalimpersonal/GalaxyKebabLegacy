﻿
using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System;

public class ClockDigital : MonoBehaviour
{
    float minutes = 0f;
    float seconds = 0f;
    float milliseconds = 0f;
    string minutesS ="";
    string secondsS = "";
    string millisecondsS = "";
    public Text txt;
    void Update()
    {

        if (milliseconds >= 100)
        {
            if (seconds >= 59)
            {
                minutes++;
                seconds = 0;
            }
            else if (seconds < 59)
            {
                seconds++;
            }
            milliseconds = 0;
        }
        milliseconds += Time.deltaTime * 100;
        if (minutes < 5)
        {
            minutesS = "0" +minutes;
        }
        else
        {
            minutesS = "" +minutes;
        }

        if (seconds < 10)
        {
            secondsS = "0" +seconds;
        }
        else
        {
            secondsS = "" +seconds;
        }

        if ((int)milliseconds < 10)
        {
            millisecondsS = "0" +(int)milliseconds;
        }
        else
        {
            millisecondsS = "" +(int)milliseconds;
        }

        txt.text = string.Format("{0}:{1}:{2}", minutesS, secondsS, millisecondsS);
    }

}