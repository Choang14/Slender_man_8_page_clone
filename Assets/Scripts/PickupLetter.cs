using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupLetter : MonoBehaviour
{
    public GameObject crayonTextObj, interactText;
    public AudioSource pickupSound;
    public bool interactable;
    public static int crayonsCollected;

    void Start()
    {
        crayonsCollected = 0;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            interactText.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            interactText.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.E))
        {
            TextMeshProUGUI crayonText = crayonTextObj.GetComponent<TextMeshProUGUI>();

            crayonsCollected++;
            crayonText.SetText("{0}/8 Crayons", crayonsCollected);
            crayonTextObj.SetActive(true);
            // pickupSound.Play();

            interactText.SetActive(false);
            this.gameObject.SetActive(false);
            interactable = false;
        }
    }
}
