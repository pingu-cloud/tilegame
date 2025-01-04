using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    public int x, y; // Grid coordinates
    public Material[] normalMaterials; // Array of normal materials (3 colors)
    public Material hoverMaterial; // Material for hovering
    public Material selectMaterial; // Material for selection

    private Renderer cubeRenderer;
    public Material originalMaterial { get; private set; }

    private bool isSelected = false; // Track if the cube is currently selected
    private bool isInteractable = true; // Track if the cube can respond to interactions

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();

        // Randomly assign one of the normal materials
        AssignRandomColor();
    }

    public void SetCoordinates(int gridX, int gridY)
    {
        x = gridX;
        y = gridY;
        name = $"Cube ({x}, {y})"; // Optional: Name the cube for debugging
    }

    public void HighlightSelected()
    {
        if (isInteractable && selectMaterial != null)
        {
            cubeRenderer.material = selectMaterial;
            isSelected = true;
        }
    }

    public void RevertMaterial()
    {
        if (originalMaterial != null)
        {
            cubeRenderer.material = originalMaterial;
            isSelected = false;
        }
    }

    public bool HasSameColor(CubeBehavior other)
    {
        return this.originalMaterial == other.originalMaterial;
    }

    void OnMouseEnter()
    {
        // Highlight the cube if it's not selected and is interactable
        if (isInteractable && !isSelected && hoverMaterial != null)
        {
            cubeRenderer.material = hoverMaterial;
        }
    }

    void OnMouseExit()
    {
        // Revert to the original material if it's not selected and is interactable
        if (isInteractable && !isSelected)
        {
            cubeRenderer.material = originalMaterial;
        }
    }

    void OnMouseDown()
    {
        if (isInteractable)
        {
            GameManager.Instance.OnCubeSelected(this); // Notify the GameManager of the selection
        }
    }

    public void ResetCubeState()
    {
        // Ensure the cube is interactable and reset selection state
        isInteractable = true;
        isSelected = false;
        AssignRandomColor();
    }

    private void AssignRandomColor()
    {
        if (normalMaterials != null && normalMaterials.Length > 0)
        {
            originalMaterial = normalMaterials[Random.Range(0, normalMaterials.Length)];
            cubeRenderer.material = originalMaterial;
        }
    }
}
