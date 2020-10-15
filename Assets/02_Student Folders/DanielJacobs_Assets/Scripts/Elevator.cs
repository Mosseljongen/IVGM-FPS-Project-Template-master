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
    public GameObject Cube;
    public GameObject Player;

    bool elevatorup = false;
    float speed = 1.0f;
    private void Update()
    {
        if (Cube.transform.localPosition.y <= 16)
        {
            if (elevatorup == true)
            {
                Cube.transform.position += Cube.transform.up * Time.deltaTime;
                
            }
        }
        if (Cube.transform.localPosition.y >= 3.76)
        {
            if (elevatorup == false)
            {
                Cube.transform.position -= Cube.transform.up * Time.deltaTime;
                
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("werkt");
        if (other.gameObject == Player)
        {
           elevatorup = true;
           
            Player.transform.parent = transform;
            Debug.Log("werkt3");
            
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("werkt2");
        if (other.gameObject == Player)
        {
            elevatorup = false;
            Debug.Log("werkt4");
            Player.transform.parent = null;
        }
    }
}

