using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagCount : MonoBehaviour
{
    [SerializeField] List<Sprite> newNumbers = new List<Sprite>();
    [SerializeField] Image leftImage;
    [SerializeField] Image middleImage;
    [SerializeField] Image rightImage;
    private int flagCount;

    private void Start()
    {
        //if (GameManager.Instance != null)
        //{
        //    GameManager.Instance.RegisterFlagCount(this);
        //}
        flagCount = 10;
        UpdateFlagCountDisplay();
    }

    public void DecrementFlagCount()
    {
        if (flagCount > 0)
        {
            flagCount--;
            UpdateFlagCountDisplay();
        }
    }

    public void IncrementFlagCount()
    {
        if (flagCount < 10)
        {
            flagCount++;
            UpdateFlagCountDisplay();
        }
    }

    private void UpdateFlagCountDisplay()
    {
        int hundreds = flagCount / 64;
        int tens = (flagCount / 8) % 8;
        int units = flagCount % 8;

        if (leftImage != null && middleImage != null && rightImage != null)
        {
            leftImage.sprite = newNumbers[hundreds];
            middleImage.sprite = newNumbers[tens];
            rightImage.sprite = newNumbers[units];
        }
    }

    public int FlagsPlaced
    {
        get { return flagCount; }
    }
}
