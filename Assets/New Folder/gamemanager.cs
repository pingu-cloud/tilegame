using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private CubeBehavior firstSelectedCube = null;
    public ScoreManager scoremanager;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnCubeSelected(CubeBehavior selectedCube)
    {
        if (firstSelectedCube == null)
        {
            // First cube selected
            firstSelectedCube = selectedCube;
            selectedCube.HighlightSelected();
        }
        else if (firstSelectedCube == selectedCube)
        {
            // Deselect the same cube
            firstSelectedCube.RevertMaterial();
            firstSelectedCube = null;
        }
        else
        {
            // Second cube selected
            if (AreAdjacent(firstSelectedCube, selectedCube) && firstSelectedCube.HasSameColor(selectedCube))
            {
                // Deactivate both cubes if they are adjacent and have the same color
                DeactivateCube(firstSelectedCube);
                DeactivateCube(selectedCube);
                scoremanager.IncreaseScore();
            }
            else
            {
                // Revert the first cube's material if the second cube doesn't match
                firstSelectedCube.RevertMaterial();
            }

            // Reset the first selected cube
            firstSelectedCube = null;
        }
    }

    private bool AreAdjacent(CubeBehavior cube1, CubeBehavior cube2)
    {
        // Check adjacency by grid coordinates
        int dx = Mathf.Abs(cube1.x - cube2.x);
        int dy = Mathf.Abs(cube1.y - cube2.y);
        return (dx + dy == 1); // True if cubes are adjacent
    }

    private void DeactivateCube(CubeBehavior cube)
    {
        // Deactivate the cube and schedule reactivation
        cube.gameObject.SetActive(false);
        StartCoroutine(ReactivateCubeAfterDelay(cube));
    }

    private IEnumerator ReactivateCubeAfterDelay(CubeBehavior cube)
    {
        yield return new WaitForSeconds(0.8f); // Delay before reactivation

        // Reactivate the cube and reset its state
        cube.gameObject.SetActive(true);
        cube.ResetCubeState();
    }
}
