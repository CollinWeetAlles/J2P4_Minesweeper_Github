using UnityEngine;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{
    private int width;
    private int height;
    private int numberOfBombs;
    public GameObject tilePrefab;
    public Transform mineField;
    public Tile[,] grid;

    void Start()
    {
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
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        grid = new Tile[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject newTile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity, mineField);
                grid[x, y] = newTile.GetComponent<Tile>();
                newTile.name = $"Tile_{x}_{y}";
                grid[x, y].SetGridPosition(x, y);
                grid[x, y].gridManager = this;
            }
        }

        AssignMines();
        CalculateNumbers();
    }
    private void AssignMines()
    {
        int minesToPlace = numberOfBombs;
        while (minesToPlace > 0)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            if (!grid[x, y].hasMine)
            {
                grid[x, y].hasMine = true;
                minesToPlace--;
            }
        }
    }
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
    public void CalculateNumbers()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (!grid[x, y].hasMine)
                {
                    int adjacentMines = CountAdjacentMines(x, y);
                    grid[x, y].surroundingMines = adjacentMines;
                    Debug.Log($"Tile ({x}, {y}) has {adjacentMines} adjacent mines.");
                }
            }
        }
    }
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
                        grid[neighborX, neighborY].RevealTile();
                    }
                }
            }
        }
    }
    public void RevealAllBombs()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (grid[x, y].hasMine)
                {
                    grid[x, y].RevealBomb();
                }
            }
        }
    }
    public void EndGame()
    {
        SceneManager.LoadScene("EndScreen");
    }
}