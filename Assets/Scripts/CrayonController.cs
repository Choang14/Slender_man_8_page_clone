using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrayonController : MonoBehaviour
{
    public int numCrayons = 0;
    public TextMeshProUGUI crayonCountText;

    private List<Transform> crayonPositions = new List<Transform>();
    private float minDistanceBetweenCrayons = 2.0f;

    void Start()
    {
        // Find all crayon positions in the scene
        foreach (GameObject crayonPositionObj in GameObject.FindGameObjectsWithTag("CrayonPosition"))
        {
            crayonPositions.Add(crayonPositionObj.transform);
        }

        // Place crayons at random valid positions
        for (int i = 0; i < numCrayons; i++)
        {
            Transform position = GetRandomPosition();
            Instantiate(Resources.Load("Prefabs/Crayon"), position.position, Quaternion.identity);
        }
    }

    private Transform GetRandomPosition()
    {
        Transform position = null;
        bool positionIsValid = false;

        while (!positionIsValid)
        {
            position = crayonPositions[Random.Range(0, crayonPositions.Count)];

            positionIsValid = true;

            foreach (Transform selectedPosition in crayonPositions)
            {
                if (Vector3.Distance(position.position, selectedPosition.position) < minDistanceBetweenCrayons)
                {
                    positionIsValid = false;
                    break;
                }
            }
        }

        return position;
    }

    public void IncrementCrayonCount()
    {
        numCrayons++;
        crayonCountText.text = "Crayons: " + numCrayons.ToString();
    }
}