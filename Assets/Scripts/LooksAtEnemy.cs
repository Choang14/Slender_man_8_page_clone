using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LooksAtEnemy : MonoBehaviour
{
    public float drainRate, rechargeRate, audioIncreaseRate, audioDecreaseRate, playersHealth, healthDamage, healthRecharge;
    public bool canRecharge;
    public Image overlayImage;
    public Slider healthBar;
    public Color color;
    public AudioSource lookedAtSound;
    public string deathScene;
    public LayerMask worldLayer;

    void Start()
    {
        color.a = 0f;
        playersHealth = 100f;

    }


    void FixedUpdate()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out var hit, Mathf.Infinity, worldLayer))
        {
            GameObject other = hit.collider.gameObject;
            Debug.Log(other.name);

            if (other.name == "EnemyInView")
            {
                Looking();
            }
            else
            {
                NotLooking();
            }
        }
        else
        {
            NotLooking();
        }


        healthBar.value = playersHealth;
        if (playersHealth <= 0)
        {
            Debug.Log("Player is dead.");
            SceneManager.LoadScene(sceneName: deathScene);
        }
    }

    void Looking()
    {
        float newTime = color.a + rechargeRate * Time.deltaTime;
        color.a = Mathf.Min(1, newTime);
        overlayImage.color = color;

        //float newVolume = lookedAtSound.volume + audioIncreaseRate * Time.deltaTime;
        //lookedAtSound.volume = Mathf.Min(1, newVolume);

        lookedAtSound.volume = lookedAtSound.volume + audioIncreaseRate * Time.deltaTime;

        playersHealth -= healthDamage * Time.deltaTime;

    }

    void NotLooking()
    {
        float newTime = color.a - drainRate * Time.deltaTime;
        color.a = Mathf.Max(newTime, 0);
        overlayImage.color = color;

        //float newVolume = lookedAtSound.volume + audioIncreaseRate * Time.deltaTime;
        //lookedAtSound.volume = Mathf.Max(newVolume, 0);

        lookedAtSound.volume = lookedAtSound.volume - audioDecreaseRate * Time.deltaTime;

        if (canRecharge)
        {
            float health = playersHealth + healthRecharge * Time.deltaTime;
            playersHealth = Mathf.Min(100, health);
        }
    }
}
