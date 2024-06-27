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
    public bool isRevealed = false;
    private int gridX, gridY;
    public GridManager gridManager;
    public FlagCount flagCountScript; // Reference to the FlagCount script

    protected override void Start()
    {
        base.Start();
        img.sprite = tiles[currentSprite];

        // Ensure flagCountScript is properly assigned
        if (flagCountScript == null)
        {
            flagCountScript = FindObjectOfType<FlagCount>();
            if (flagCountScript == null)
            {
                Debug.LogError("FlagCount script not found in the scene.");
            }
        }
    }

    protected override void LeftClick()
    {
        if (isFlagged || isRevealed) return;

        if (hasMine)
        {

            Debug.Log("You have touched a bomb (GAME OVER)");
            currentSprite = 13; // Bomb sprite

            img.sprite = tiles[currentSprite];
            gridManager.RevealAllBombs();

        }
        else
        {
            Debug.Log($"LeftClick on tile ({gridX}, {gridY})");
            RevealTile();
        }
    }

    protected override void MiddleClick()
    {
        if (isFlagged) return;
        Debug.Log("MiddleClick");
    }

    protected override void RightClick()
    {
        Debug.Log($"RightClick on tile ({gridX}, {gridY})");
        PlaceFlag();
    }

    public void PlaceFlag()
    {
        if (isRevealed) return;

        if (!isFlagged)
        {
            currentSprite = 1;
            img.sprite = tiles[currentSprite];
            isFlagged = true;
            if (flagCountScript != null)
            {
                flagCountScript.DecrementFlagCount();
            }
        }
        else
        {
            currentSprite = 3;
            img.sprite = tiles[currentSprite];
            isFlagged = false;
            if (flagCountScript != null)
            {
                flagCountScript.IncrementFlagCount();
            }
        }
    }

    public void RevealBomb()
    {
        if (hasMine)
        {
            if (isFlagged)
            {
                currentSprite = 12;
                img.sprite = tiles[currentSprite];
            }
            else
            {
                currentSprite = 2; // Bomb sprite
                img.sprite = tiles[currentSprite];
                isRevealed = true;
            }
        }
    }

    public void RevealTile()
    {
        if (isRevealed) return;

        isRevealed = true;
        int adjacentMines = gridManager.CountAdjacentMines(gridX, gridY);
        Debug.Log($"Tile ({gridX}, {gridY}) has {adjacentMines} adjacent mines.");

        if (adjacentMines > 0)
        {
            currentSprite = 3 + adjacentMines;
            img.sprite = tiles[currentSprite];
        }
        else
        {
            currentSprite = 0;
            img.sprite = tiles[currentSprite];
            gridManager.RevealAdjacentTiles(gridX, gridY);
        }
    }

    public void SetGridPosition(int x, int y)
    {
        gridX = x;
        gridY = y;
    }

    public void EndGame()
    {
        SceneManager.LoadScene("EndScreen");
    }
}
             