using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public Transform[] teleportationZones;
    public Transform player;
    public float teleportRateSeconds;
    bool teleporting = true;
    int random_number;

    void Start()
    {
        StartCoroutine(teleport());
    }

    void Update()
    {
        this.transform.LookAt(new Vector3(player.position.x, this.transform.position.y, player.position.z));
    }

    IEnumerator teleport()
    {
        while (teleporting)
        {
            yield return new WaitForSeconds(teleportRateSeconds);
            int random_number = Random.Range(0, teleportationZones.Length);
            this.transform.position = teleportationZones[random_number].position;
        }
    }

}
