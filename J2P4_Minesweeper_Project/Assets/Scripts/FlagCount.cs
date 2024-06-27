using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagCount : BaseUI
{
    private int flagCount;   // Current count of flags

    private void Start()
    {
        flagCount = 10;             // Initialize flag count to 10
        UpdateFlagCountDisplay();   // Update UI to display initial flag count
    }

    // Decrements the flag count by 1, if greater than 0
    public void DecrementFlagCount()
    {
        if (flagCount > 0)
        {
            flagCount--;            // Decrease flag count
            UpdateFlagCountDisplay();   // Update UI to reflect new flag count
        }
    }

    // Increments the flag count by 1, if less than 10
    public void IncrementFlagCount()
    {
        if (flagCount < 10)
        {
            flagCount++;            // Increase flag count
            UpdateFlagCountDisplay();   // Update UI to reflect new flag count
        }
    }

    // Updates the UI to display the current flag count
    private void UpdateFlagCountDisplay()
    {
        UpdateDisplay(flagCount);   // Call method from base class to update UI display
    }

    // Property to get the current number of flags placed
    public int FlagsPlaced
    {
        get { return flagCount; }   // Return current flag count
    }
}