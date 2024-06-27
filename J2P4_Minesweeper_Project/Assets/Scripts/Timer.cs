using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : BaseUI
{
    public int timerValue = 0;
    private bool turnOnWhileLoop = true;

    private void Start()
    {
        StartCoroutine(Run());
    }

    public IEnumerator Run()
    {
        while (turnOnWhileLoop)
        {
            timerValue++;
            UpdateDisplay(timerValue);
            yield return new WaitForSeconds(1);
        }
    }

    public void StopTimer()
    {
        turnOnWhileLoop = false;
    }
}