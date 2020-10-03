﻿using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public GameObject keysHelp;
    public float targetTime = 3.0f;

    public bool shouldCount = false;

    // Update is called once per frame
    void Update()
    {
        if (shouldCount)
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 1.0f)
            {
                timer.text = "Go !";
                shouldCount = false;
                FindObjectOfType<PlayerMovement>().shouldRun = true;
            }
            else
            {
                timer.text = targetTime.ToString("0");
            }
        }
    }

    public void StartTimer()
    {
        shouldCount = true;
    }

    public void StopTimer()
    {
        shouldCount = false;
    }
}
