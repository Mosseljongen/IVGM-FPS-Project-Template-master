using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToMovingPlatform : MonoBehaviour
{
    public GameObject Player;
    public GameObject Floor;
    public AudioSource source;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Destroy(Floor);
            source.Play();
        }
    }
}
