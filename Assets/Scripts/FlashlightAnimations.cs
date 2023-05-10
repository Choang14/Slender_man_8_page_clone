using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightAnimations : MonoBehaviour
{
    public Animator flashlight;

    void Update()
    {
        bool player_is_moving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        bool player_is_sprinting = Input.GetKey(KeyCode.LeftShift);

        if (player_is_moving && player_is_sprinting)
        {
            flashlight.ResetTrigger("walk");
            flashlight.SetTrigger("sprint");
        }
        else
        {
            flashlight.ResetTrigger("sprint");
            flashlight.SetTrigger("walk");
        }
    }
}
