using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Base class for tiles in the game grid, inherits from ClickHandler
public abstract class BaseTile : ClickHandler
{
    public bool hasMine;                // Flag indicating if the tile has a mine
    public int surroundingMines;        // Number of mines adjacent to this tile
    public Image img;                   // Image component for displaying tile sprites
    public List<Sprite> tiles;          // List of sprites representing different tile states
    protected int currentSprite = 3;    // Index of the current sprite in tiles list
    protected bool isFlagged = false;   // Flag indicating if the tile is flagged
    public bool isRevealed = false;     // Flag indicating if the tile is revealed
    protected int gridX, gridY;         // Grid coordinates of the tile
    public GridManager gridManager;     // Reference to the GridManager managing this tile

    // Sets the grid position of the tile
    public virtual void SetGridPosition(int x, int y)
    {
        gridX = x;      // Set x coordinate
        gridY = y;      // Set y coordinate
    }

    // Reveals the tile
    public virtual void RevealTile()
    {
        if (isRevealed) return; // If already revealed, exit

        isRevealed = true;  // Mark tile as revealed
        int adjacentMines = gridManager.CountAdjacentMines(gridX, gridY);  // Count adjacent mines

        if (adjacentMines > 0)
        {
            currentSprite = 3 + adjacentMines;  // Set sprite index based on adjacent mines
            img.sprite = tiles[currentSprite];  // Update sprite to show number of adjacent mines
        }
        else
        {
            currentSprite = 0;  // Set sprite index for empty tile
            img.sprite = tiles[currentSprite];  // Update sprite to show empty tile
            gridManager.RevealAdjacentTiles(gridX, gridY);  // Reveal adjacent tiles
        }
    }

    // Abstract method to place a flag on the tile
    public abstract void PlaceFlag();

    // Abstract method to reveal the tile as a bomb
    public abstract void RevealBomb();
}
