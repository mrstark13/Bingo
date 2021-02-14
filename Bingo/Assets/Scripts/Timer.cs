using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText; //Общее время
    static string timerString;
    static private float timer;
    public static float valueTimer
    {
        get { return timer; }
        set
        {
            timer = value;
            timerString = ((int)value / 60).ToString() + ":" + ((int)value % 60).ToString();
        }
    }


    void Start()
    {
        valueTimer = 1200; //20 минут для теста
    }
    void Update()
    {
        if (valueTimer > 0)
        {
            valueTimer -= Time.deltaTime;
            timerText.text = timerString;
        }
    }
}
