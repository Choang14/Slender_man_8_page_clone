using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupCrayon : MonoBehaviour
{
    public GameObject crayonTextObj, interactText;
    public AudioSource pickupSound;
    public LayerMask worldLayer;
    public static int crayonsCollected;
    private bool canGrab;

    void Start()
    {
        crayonsCollected = 0;
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(ray.origin, ray.direction * 2);

        if (Physics.Raycast(ray, out var hit, 2, worldLayer))
        {
            GameObject other = hit.collider.gameObject;
            Debug.Log(other.name);

            if (other.tag == "Crayon")
            {
                interactText.SetActive(true);
                canGrab = true;
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
            TextMeshProUGUI crayonText = crayonTextObj.GetComponent<TextMeshProUGUI>();

            crayonsCollected++;
            crayonText.SetText("{0}/8 Crayons", crayonsCollected);
            crayonTextObj.SetActive(true);
            // pickupSound.Play();

            interactText.SetActive(false);
            this.gameObject.SetActive(false);
            canGrab = false;
        }
    }
}
