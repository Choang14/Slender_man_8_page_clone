using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrayonController : MonoBehaviour
{
    public int numCrayons = 0;
    public int totalCrayons = 8; // Add a variable for the total number of crayons
    public TextMeshProUGUI crayonCountText;

    private List<Transform> crayonPositions = new List<Transform>();

    void Start()
    {
        // Find all crayon positions in the scene
        foreach (GameObject crayonPositionObj in GameObject.FindGameObjectsWithTag("CrayonPosition"))
        {
            crayonPositions.Add(crayonPositionObj.transform);
        }

        // Place crayons at random valid positions
        for (int i = 0; i < totalCrayons; i++) // Use totalCrayons instead of numCrayons
        {
            Transform position = GetRandomPosition();
            Instantiate(Resources.Load("Prefabs/Crayon"), position.position, Quaternion.identity);
        }

        UpdateCrayonCountText(); // Update the text on start
    }

    private Transform GetRandomPosition()
    {
        Transform position = null;
        bool positionIsValid = false;

        while (!positionIsValid)
        {
            position = crayonPositions[Random.Range(0, crayonPositions.Count)];

            positionIsValid = true;
        }

        return position;
    }

    public void IncrementCrayonCount()
    {
        numCrayons++;
        UpdateCrayonCountText(); // Call the new UpdateCrayonCountText() method
    }

    private void UpdateCrayonCountText()
    {
        crayonCountText.text = "Crayons: " + numCrayons.ToString() + "/" + totalCrayons.ToString(); // Update the text to show the current count and total count
    }
}