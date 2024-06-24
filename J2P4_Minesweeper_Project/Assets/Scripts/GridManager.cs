using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 9;
    public int height = 9;
    public GameObject tilePrefab;
    public Transform mineField;

    private Tile[,] grid;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        grid = new Tile[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject newTile = Instantiate(tilePrefab, new Vector3(x, y, 0), Quaternion.identity, mineField);
                grid[x, y] = newTile.GetComponent<Tile>();
                newTile.name = $"Tile_Save";
            }
        }
    }

    void PlaceMines()
    {
        // Mine placing logic
    }

    void CalculateNumbers()
    {
        // Number logic
    }
}