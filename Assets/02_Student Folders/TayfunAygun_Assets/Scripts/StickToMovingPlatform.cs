using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToMovingPlatform : MonoBehaviour
{
    public GameObject Player;
    public GameObject Floor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Destroy(Floor);
        }
    }
}
