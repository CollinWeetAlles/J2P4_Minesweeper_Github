using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Base class for UI elements, inherits from MonoBehaviour
public abstract class BaseUI : MonoBehaviour
{
    [SerializeField] protected List<Sprite> numbers = new List<Sprite>();   // List of sprites representing numbers
    [SerializeField] protected Image leftImage;                             // Image component for displaying hundreds place
    [SerializeField] protected Image middleImage;                           // Image component for displaying tens place
    [SerializeField] protected Image rightImage;                            // Image component for displaying units place

    // Updates the display with the given value
    protected virtual void UpdateDisplay(int value)
    {
        // Separate value into hundreds, tens, and units
        int hundreds = (value / 100) % 10;
        int tens = (value / 10) % 10;
        int units = value % 10;

        // Update UI images if they are assigned
        if (leftImage != null && middleImage != null && rightImage != null)
        {
            leftImage.sprite = numbers[hundreds];    // Display hundreds place number sprite
            middleImage.sprite = numbers[tens];      // Display tens place number sprite
            rightImage.sprite = numbers[units];      // Display units place number sprite
        }
    }
}
