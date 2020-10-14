using UnityEngine;
using System.Collections;

public class LittleDoorScript : MonoBehaviour
{

    private bool doorOpen = false;
    private Ray ray;
    private RaycastHit hit;
    private float distance = 5.0f;
    public GameObject door;

    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.collider.gameObject.name == door.name)
                {
                    if (!doorOpen)
                    {
                        Quaternion targetRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                        hit.transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 2.0f);
                        doorOpen = true;
                    }
                    else
                    {
                        Quaternion targetRotation2 = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                        hit.transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, 2.0f);
                        doorOpen = false;
                    }
                }
            }
        }
    }
}