/* using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Crayon : MonoBehaviour
{
    public float speed = 5f;
    public int totalCrayons = 8;
    public GameObject promptText;
    public GameObject crayonPrefab;
    public GameObject winCanvas;
    public Button restartButton;
    public Button menuButton;
    private bool canPickupCrayon = false;
    private Collider crayonCollider;
    private List<Transform> crayonPositions = new List<Transform>();
    public CrayonController crayonController; // Add reference to the CrayonController script

    void Start()
    {
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


   *private void CollectCrayon(Collider crayon)
    {
        crayonController.IncrementCrayonCount(); // Call the IncrementCrayonCount() method from the CrayonController script
        Destroy(crayon.gameObject);
        if (crayonController.numCrayons == totalCrayons) // Check the crayon count from the CrayonController script
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
} */