using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class showScript : MonoBehaviour
{
    public GameObject obj;
    bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacterController player = other.GetComponent<PlayerCharacterController>();

        if (player == null) { return; }
        if (!activated)
        {
            obj.GetComponent<Renderer>().enabled = true;
            activated = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerCharacterController player = other.GetComponent<PlayerCharacterController>();

        if (player == null) { return; }
        if (activated)
        {
            obj.GetComponent<Renderer>().enabled = false;
            activated = false;
        }

    }



}
