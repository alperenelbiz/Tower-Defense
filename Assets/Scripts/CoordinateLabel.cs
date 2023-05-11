using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabel : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Tile tile;
    GridManager gridManager;

    Scene currentScene;
    string sceneName;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        tile = GetComponentInParent<Tile>();
        DisplayCoordinates();

        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }



    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        SetLabelColor();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        /*if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }*/
    }

    void SetLabelColor()
    {
        if (sceneName == "Pathless")
        {
            if (gridManager == null) { return; }

            Node node = gridManager.GetNode(coordinates);

            if (node == null) { return; }

            if (!node.isWalkable)
            {
                label.color = blockedColor;
            }

            else if (node.isPath)
            {
                label.color = pathColor;
            }

            else if (node.isExplored)
            {
                label.color = exploredColor;
            }

            else
            {
                label.color = defaultColor;
            }
        }

        else if (sceneName == "Normal")
        {
            if (tile.IsPlaceable)
            {
                label.color = defaultColor;
            }

            else
            {
                label.color = blockedColor;
            }
        }
    }

    void DisplayCoordinates()
    {
        if (gridManager == null) { return; }

        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / gridManager.UnityGridSize);

        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
