using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    public GameObject footstep;

    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey ("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            footsteps();
        }
        else
        {
            stopFootsteps();
        }
    }

    void footsteps()
    {
        footstep.SetActive(true);
    }

    void stopFootsteps()
    {
        footstep.SetActive(false);
    }
}
