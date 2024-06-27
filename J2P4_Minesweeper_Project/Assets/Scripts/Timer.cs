using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] List<Sprite> numbers = new List<Sprite>();
    [SerializeField] Image leftImage;
    [SerializeField] Image middleImage;
    [SerializeField] Image rightImage;
    public int timerValue = 0;
    private bool turnOnWhileLoop = true;

    private void Start()
    {
        //if (GameManager.Instance != null)
        //{
        //    GameManager.Instance.RegisterTimer(this);
        //}
        StartCoroutine(Run());
    }

    public IEnumerator Run()
    {
        while (turnOnWhileLoop)
        {
            timerValue++;

            int hundreds = (timerValue / 100) % 10;
            int tens = (timerValue / 10) % 10;
            int units = timerValue % 10;

            if (leftImage != null && middleImage != null && rightImage != null)
            {
                leftImage.sprite = numbers[hundreds];
                middleImage.sprite = numbers[tens];
                rightImage.sprite = numbers[units];
            }

            yield return new WaitForSeconds(1);
        }
    }
    public void StopTimer()
    {
        turnOnWhileLoop = false;
    }
}