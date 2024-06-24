using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public GameObject tilePrefeb;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        // Making a grid / Map
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Instantiate(tilePrefeb, new Vector3(x, y, 0), Quaternion.identity);
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
