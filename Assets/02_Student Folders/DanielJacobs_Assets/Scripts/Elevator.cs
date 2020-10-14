using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    //public GameObject moveplatform;


    //private void Ontriggerstay()
    // {
    //   

    //}
    public GameObject Player;
    public GameObject Player2;
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("werkt");
        if (other.gameObject == Player2)
        {
            Player2.transform.parent = transform;
            Debug.Log("werkt3");
            Player.transform.position += Player.transform.up * Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("werkt2");
        if (other.gameObject == Player2)
        {
            Debug.Log("werkt4");
            Player2.transform.parent = null;
        }
    }
}
