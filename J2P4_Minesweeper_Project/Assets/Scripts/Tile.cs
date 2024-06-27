using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Tile : BaseTile
{
    public FlagCount flagCountScript;  // Reference to the FlagCount script
    public GameObject panel;           // Reference to a panel game object (not used in provided script)

    protected override void Start()
    {
        base.Start();                                   // Call the Start method of the base class (BaseTile)
        img.sprite = tiles[currentSprite];              // Set the sprite of the image component to the current sprite
        // Find FlagCount script if not assigned in the inspector
        if (flagCountScript == null)
        {
            flagCountScript = FindObjectOfType<FlagCount>();
        }
    }

    protected override void LeftClick()
    {
        // Ignore left click if tile is flagged or already revealed
        if (isFlagged || isRevealed) return;
        // If the tile has a mine, reveal all bombs; otherwise, reveal the tile
        if (hasMine)
        {
            currentSprite = 13;
            img.sprite = tiles[currentSprite];
            gridManager.RevealAllBombs();        // Call the grid manager's method to reveal all bombs
        }
        else
        {
            RevealTile();      // Call method to reveal the tile
        }
    }

    protected override void MiddleClick()
    {
       
        if (isFlagged) return; // Middle click behavior (not added, Ran out of time :( )
    }

    protected override void RightClick()
    {   
        PlaceFlag();           // Call method to place or remove flag on right click
    }

    // Places or removes a flag on the tile
    public override void PlaceFlag()
    {
        // Ignore if tile is already revealed
        if (isRevealed) return;

        // If not flagged, place a flag; if flagged, remove the flag
        if (!isFlagged)
        {
            currentSprite = 1;
            img.sprite = tiles[currentSprite];       // Change sprite to flag sprite
            isFlagged = true;
            if (flagCountScript != null)
            {
                flagCountScript.DecrementFlagCount();  // Decrement flag count in FlagCount script
            }
        }
        else
        {
            currentSprite = 3;
            img.sprite = tiles[currentSprite];  // Change sprite back to default tile sprite
            isFlagged = false;
            if (flagCountScript != null)
            {
                flagCountScript.IncrementFlagCount();   // Increment flag count in FlagCount script
            }
        }
    }
    // Reveals the tile as a bomb
    public override void RevealBomb()
    {
        if (hasMine)
        {
            // If the tile has a mine, reveal it differently based on whether it's flagged
            if (isFlagged)
            {
                currentSprite = 12;
                img.sprite = tiles[currentSprite];  //Flagged mine sprite
            }
            else
            {
                currentSprite = 2;
                img.sprite = tiles[currentSprite];  // Revealed mine sprite
                isRevealed = true;                  // Mark tile as revealed
            }
        }
    }
    // Override method to reveal the tile
    public override void RevealTile()
    {
        try
        {
            base.RevealTile();          // Call the base class method to reveal the tile
        }
        catch (System.Exception ex)
        {
            Debug.LogError("An error occurred in RevealTile: " + ex.Message);  // Log any exceptions
        }
    }

    // Ends the game by loading the EndScreen scene ( Again not in use also dont know why I added it 2 times :) )
    public void EndGame()
    {
        SceneManager.LoadScene("EndScreen");
    }
}
