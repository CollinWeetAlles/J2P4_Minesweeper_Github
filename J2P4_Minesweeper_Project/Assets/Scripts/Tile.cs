using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tile : ClickHandler
{
    public bool hasMine;
    public int surroundingMines;
    public Image img;
    public List<Sprite> tiles;
    private int currentSprite = 3; // Default tile sprite
    private bool isFlagged = false;
    private int gridX, gridY;
    public GridManager gridManager;

    protected override void LeftClick()
    {
        if (isFlagged || currentSprite == 0)
        {
            Debug.Log("Left click ignored: tile is flagged or already revealed.");
            return;
        }

        if (hasMine)
        {
            currentSprite = 2; // Bomb sprite
            img.sprite = tiles[currentSprite];
            Debug.Log("You have touched a bomb (GAME OVER)");
            gridManager.EndGame();
        }
        else
        {
            Debug.Log("LeftClick");
            RevealTile();
        }
    }

    protected override void MiddleClick()
    {
        if (isFlagged) return; // Prevent action if flagged

        Debug.Log($"MiddleClick on Tile at ({gridX}, {gridY})");
        // Reveal a 3 by 3 space
    }

    protected override void RightClick()
    {
        Debug.Log($"RightClick on Tile at ({gridX}, {gridY})");
        PlaceFlag();
    }

    public void PlaceFlag()
    {
        if (currentSprite == 0 || isFlagged)
        {
            Debug.Log("Flag placement ignored: tile is already flagged or revealed.");
            return;
        }

        if (!isFlagged)
        {
            currentSprite = 1; // Set to flag sprite
            img.sprite = tiles[currentSprite];
            isFlagged = true;
            Debug.Log("Flag placed");
        }
        else // isFlagged == true
        {
            currentSprite = 3; // Set back to default tile sprite
            img.sprite = tiles[currentSprite];
            isFlagged = false;
            Debug.Log("Flag removed");
        }
    }


    public void RevealTile()
    {
        if (isFlagged || currentSprite == 0) return; // Prevent revealing flagged or already revealed tiles

        // Set tile to revealed state
        currentSprite = 0; // Or the index for revealed state in your tiles list
        img.sprite = tiles[currentSprite];

        // Check if this tile has adjacent mines
        if (surroundingMines > 0)
        {
            // Show number of adjacent mines
            SetNumberSprite(surroundingMines);
        }
        else
        {
            // Trigger reveal for neighboring tiles
            for (int offsetX = -1; offsetX <= 1; offsetX++)
            {
                for (int offsetY = -1; offsetY <= 1; offsetY++)
                {
                    int neighborX = gridX + offsetX;
                    int neighborY = gridY + offsetY;
                    if (neighborX >= 0 && neighborX < gridManager.width &&
                        neighborY >= 0 && neighborY < gridManager.height &&
                        !(offsetX == 0 && offsetY == 0)) // Exclude the current tile
                    {
                        gridManager.grid[neighborX, neighborY].LeftClick(); // Recursive call
                    }
                }
            }
        }
    }


    public void SetNumberSprite(int number)
    {
        if (number > 0 && number <= 8)
        {
            currentSprite = number + 2; // Adjust index to match your tiles array
            img.sprite = tiles[currentSprite];
        }
        else if (number == 0)
        {
            currentSprite = 0; // Revealed tile sprite for zero adjacent mines
            img.sprite = tiles[currentSprite];
        }
        // Ensure you handle other cases as needed
    }

    public void SetGridPosition(int x, int y)
    {
        gridX = x;
        gridY = y;
    }

    public void SetGridManager(GridManager manager)
    {
        gridManager = manager;
    }
}
