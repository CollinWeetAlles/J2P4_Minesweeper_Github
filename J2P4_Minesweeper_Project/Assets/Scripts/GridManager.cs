using UnityEngine;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{
    public int width = 9;
    public int height = 9;
    public GameObject tilePrefab;
    public Transform mineField;
    public Tile[,] grid;

    void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        grid = new Tile[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject newTile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity, mineField);
                Tile tileComponent = newTile.GetComponent<Tile>();
                grid[x, y] = tileComponent;
                newTile.name = $"Tile_{x}_{y}";
                tileComponent.SetGridPosition(x, y);
                tileComponent.SetGridManager(this); // Set the GridManager
            }
        }

        // Assign mines randomly and calculate numbers
        AssignMines();
        CalculateNumbers();
    }

    public void AssignMines()
    {
        int minesToPlace = 10; // Example value, adjust as needed
        while (minesToPlace > 0)
        {
            int x = UnityEngine.Random.Range(0, width);
            int y = UnityEngine.Random.Range(0, height);
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
                    grid[x, y].surroundingMines = adjacentMines; // Store the number of adjacent mines
                }
            }
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("EndScreen");
    }
}
