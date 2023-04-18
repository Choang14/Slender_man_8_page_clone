using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource walk_sound, sprint_sound;

    void Update()
    {
        bool player_is_moving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        bool player_is_sprinting = Input.GetKey(KeyCode.LeftShift);

        sprint_sound.enabled = player_is_moving && player_is_sprinting;
        walk_sound.enabled = player_is_moving && !player_is_sprinting;
    }
}
