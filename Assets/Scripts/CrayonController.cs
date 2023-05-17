using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CrayonController : MonoBehaviour
{
    public int numCrayons = 0;
    public int totalCrayons = 0;
    public TextMeshProUGUI crayonCountText;
    public GameObject /*crayonTextObj,*/ interactText;
    public AudioSource pickupSound;
    public LayerMask worldLayer;
    private bool canGrab;
    private Collider crayonCollider;



    void Start()
    {

        // Find all existing crayons in the scene and deactivate them
        GameObject[] existingCrayons = GameObject.FindGameObjectsWithTag("Crayon");
        foreach (GameObject crayon in existingCrayons)
        {
            crayon.SetActive(false);
        }

        // Randomly select and activate 8 crayons
        for (int i = 0; i < totalCrayons; i++)
        {
            GameObject crayon;
            do
            {
                crayon = existingCrayons[Random.Range(0, existingCrayons.Length)];
            } while (crayon.activeSelf); // Ensure we select a deactivated crayon

            crayon.SetActive(true);
        }

        UpdateCrayonCountText(); // Update the text on start
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(ray.origin, ray.direction * 2);

        if (Physics.Raycast(ray, out var hit, 2, worldLayer))
        {
            GameObject other = hit.collider.gameObject;
            Debug.Log(other.name);

            if (other.CompareTag("Crayon"))
            {
                interactText.SetActive(true);
                canGrab = true;
                crayonCollider = hit.collider;
            }
            else
            {
                interactText.SetActive(false);
                canGrab = false;
            }
        }
        else
        {
            interactText.SetActive(false);
            canGrab = false;
        }
    }

    void Update()
    {
        if (canGrab && Input.GetKeyDown(KeyCode.E))
        {
            CollectCrayon(crayonCollider);
        }
    }

    public void CollectCrayon(Collider crayon)
    {
        numCrayons++;
        Destroy(crayon.gameObject);
        UpdateCrayonCountText();
        interactText.SetActive(false);
        canGrab = false;
        // pickupSound.Play();

        if (numCrayons == totalCrayons)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("You Win!");
        }
    }

    private void UpdateCrayonCountText()
    {
        crayonCountText.text = "Crayons: " + numCrayons.ToString() + "/" + totalCrayons.ToString(); // Update the text to show the current count and total count
    }
}