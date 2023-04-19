using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    //Variables 
    public float mouseSensitivity = 2000f;
    public Transform orientation;

    float yRotation;
    float xRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Collect Mouse input
        float inputX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float inputY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += inputX;

        xRotation -= inputY;

        xRotation = Mathf.Clamp (xRotation, -90.0f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
