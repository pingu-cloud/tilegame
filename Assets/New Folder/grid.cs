using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject cubePrefab; // Reference to the cube prefab
    public int gridWidth = 7; // Number of columns
    public int gridHeight = 7; // Number of rows
    public float cellSize = 1.5f; // Spacing between cubes

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 position = new Vector3(x * cellSize, 0, y * cellSize);
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity, transform);

                CubeBehavior cubeBehavior = cube.GetComponent<CubeBehavior>();
                if (cubeBehavior != null)
                {
                    cubeBehavior.SetCoordinates(x, y);
                }
            }
        }
    }
}
