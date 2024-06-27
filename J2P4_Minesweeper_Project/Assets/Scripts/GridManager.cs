using UnityEngine;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{
    private int width;                      // Width of the grid
    private int height;                     // Height of the grid
    private int numberOfBombs;              // Number of bombs to place in the grid
    public GameObject tilePrefab;           // Prefab for individual tiles in the grid
    public Transform mineField;             // Parent transform for organizing tiles in the hierarchy
    public Tile[,] grid;                    // 2D array to store references to each tile in the grid

    void Start()
    {
        // Determine grid dimensions and bomb count based on current scene
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name)
        {
            case "Easy":
                width = 9;
                height = 9;
                numberOfBombs = 10;
                Debug.Log("Executing code for Easy");
                break;

            case "Medium":
                width = 16;
                height = 16;
                numberOfBombs = 40;
                Debug.Log("Executing code for Medium");
                break;

            case "Hard":
                width = 30;
                height = 16;
                numberOfBombs = 99;
                Debug.Log("Executing code for Hard");
                break;

            default:
                break;
        }
        // Generate the grid of tiles
        GenerateGrid();
    }

    private void GenerateGrid()
    {   // Initialize the grid array
        grid = new Tile[width, height];
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                {   // Instantiate a new tile prefab at (x, y, 0) position
                    GameObject newTile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity, mineField);
                    grid[x, y] = newTile.GetComponent<Tile>(); // Get the Tile component of the new tile
                    newTile.name = $"Tile_{x}_{y}";            // Set the name of the tile
                    grid[x, y].SetGridPosition(x, y);          // Set the grid position of the tile
                    grid[x, y].gridManager = this;             // Set the grid manager reference for the tile
                }
            }
        // Assign mines randomly to tiles
        AssignMines();
        // Calculate and set the number of adjacent mines for each tile
        CalculateNumbers();
    }
    // Assigns mines randomly to tiles in the grid
    private void AssignMines()
    {
        int minesToPlace = numberOfBombs;
        while (minesToPlace > 0)
        {
            int x = Random.Range(0, width);  // Random x coordinate
            int y = Random.Range(0, height); // Random y coordinate
            if (!grid[x, y].hasMine)         // Check if the tile does not already have a mine
            {
                grid[x, y].hasMine = true;   // Set the tile to have a mine
                minesToPlace--;              // Decrease the number of mines left to place
            }
        }
    }
    // Counts and returns the number of adjacent mines for a given tile position (x, y)
    public int CountAdjacentMines(int x, int y)
    {
        int count = 0;
        for (int offsetX = -1; offsetX <= 1; offsetX++)
        {
            for (int offsetY = -1; offsetY <= 1; offsetY++)
            {
                int neighborX = x + offsetX;
                int neighborY = y + offsetY;
                if (neighborX >= 0 && neighborX < width && neighborY >= 0 && neighborY < height)
                {
                    if (grid[neighborX, neighborY].hasMine)
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }
    // Calculates and sets the number of adjacent mines for each tile in the grid
    private void CalculateNumbers()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (!grid[x, y].hasMine)                            // If the tile does not have a mine
                {
                    int adjacentMines = CountAdjacentMines(x, y);   // Count adjacent mines
                    grid[x, y].surroundingMines = adjacentMines;    // Set the number of adjacent mines for the tile
                }
            }
        }
    }
    // Reveals all adjacent tiles that do not have a mine and are not yet revealed
    public void RevealAdjacentTiles(int x, int y)
    {
        for (int offsetX = -1; offsetX <= 1; offsetX++)
        {
            for (int offsetY = -1; offsetY <= 1; offsetY++)
            {
                int neighborX = x + offsetX;
                int neighborY = y + offsetY;
                if (neighborX >= 0 && neighborX < width && neighborY >= 0 && neighborY < height)
                {
                    if (!grid[neighborX, neighborY].hasMine && !grid[neighborX, neighborY].isRevealed)
                    {
                        grid[neighborX, neighborY].RevealTile(); // Reveal the adjacent tile
                    }
                }
            }
        }
    }
    // Reveals all tiles that have mines (game over condition)
    public void RevealAllBombs()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (grid[x, y].hasMine)
                {
                    grid[x, y].RevealBomb(); // Reveal the bomb tile
                }
            }
        }
    }

    // Ends the game by loading the EndScreen scene ( Is not in use anymore )
    public void EndGame()
    {
        SceneManager.LoadScene("EndScreen");
    }
}