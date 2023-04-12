using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Crayon : MonoBehaviour
{
    public float speed = 5f;
    public int totalCrayons = 8;
    public Text uiText;
    public GameObject promptText;
    public GameObject crayonPrefab;
    public GameObject winCanvas;
    public Button restartButton;
    public Button menuButton;
    private int currentCrayons = 0;
    private bool canPickupCrayon = false;
    private Collider crayonCollider;
    private List<Transform> crayonPositions = new List<Transform>();

    void Start()
    {
        // Find all the crayon positions in the scene
        GameObject[] crayonPositionObjects = GameObject.FindGameObjectsWithTag("CrayonPosition");
        foreach (GameObject crayonPositionObject in crayonPositionObjects)
        {
            crayonPositions.Add(crayonPositionObject.transform);
        }

        // Randomly select 8 positions from the list of crayon positions
        List<Transform> selectedPositions = new List<Transform>();
        while (selectedPositions.Count < totalCrayons)
        {
            Transform randomPosition = crayonPositions[Random.Range(0, crayonPositions.Count)];
            bool positionTooClose = false;
            foreach (Transform selectedPosition in selectedPositions)
            {
                if (Vector3.Distance(randomPosition.position, selectedPosition.position) < 2f)
                {
                    positionTooClose = true;
                    break;
                }
            }
            if (!positionTooClose)
            {
                selectedPositions.Add(randomPosition);
            }
        }

        // Instantiate a crayon at each selected position
       /* foreach (Transform selectedPosition in selectedPositions)
        {
            Instantiate(crayonPrefab, selectedPosition.position, selectedPosition.rotation);
        } */

        // Initialize the UI text
        uiText.text = "Crayons Collected: 0/" + totalCrayons.ToString();
        promptText.SetActive(false);
        winCanvas.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
        menuButton.onClick.AddListener(ExitToMenu);
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        transform.Translate(movement * speed * Time.deltaTime);

        if (canPickupCrayon && Input.GetKeyDown(KeyCode.F))
        {
            CollectCrayon(crayonCollider);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crayon"))
        {
            // Show prompt text to player
            canPickupCrayon = true;
            promptText.SetActive(true);
            crayonCollider = other; // Save the reference to the crayon collider
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Crayon"))
        {
            // Hide prompt text from player
            canPickupCrayon = false;
            promptText.SetActive(false);
        }
    }

    private void CollectCrayon(Collider crayon)
    {
        currentCrayons++;
        uiText.text = "Crayons Collected: " + currentCrayons.ToString() + "/" + totalCrayons.ToString();
        Destroy(crayon.gameObject);
        if (currentCrayons == totalCrayons)
        {
            // Show win canvas and disable movement
            winCanvas.SetActive(true);
        }
    }

    private void RestartGame()
    {
        // Reload the current scene to restart the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    private void ExitToMenu()
    {
        // Load the menu scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}