using UnityEngine;
using System.Collections;

public class Doo : MonoBehaviour
{

    private bool doorOpen = false;
    private Ray ray;
    private RaycastHit hit;
    private float distance = 5.0f;
    public GameObject door;
    public GameObject chamber;
    public bool[,] Walls;
    private int x_init_d;
    private int z_init_d;
    private int z_off;
    private int x_off;
    private int side_d;
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
                       
                        chamber = Instantiate(chamber, new Vector3(0, 0, 0), Quaternion.identity);
                        chamber.GetComponent <Chamber> ().Initialise(4, 4, 1,transform.position.x + x_off, transform.position.y,transform.position.z + z_off, ref Walls, x_init_d, z_init_d,side_d);
                        //Quaternion targetRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                        //hit.transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 2.0f);
                        doorOpen = true;
                    }
                    else
                    {
                        //Quaternion targetRotation2 = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                        //hit.transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, 2.0f);
                        doorOpen = false;
                    }
                }
            }
        }
    }
    public void Initialise(ref bool[,] taken, int x_init, int z_init,int side)
    {
        side_d = side;
        Walls = taken;
        if (side ==1) {
            x_init_d = x_init ;
            z_init_d = z_init;
            x_off = -1;
            z_off = 0;
        }
        if (side == 2)
        {
            x_init_d = x_init;
            z_init_d = z_init;
            x_off = -8;
            z_off = -1;

        }
        if (side == 3)
        {
            x_init_d = x_init ;
            z_init_d = z_init;
            x_off = -1;
            z_off = -8;
        }
        if (side == 0) {
            x_init_d = x_init;
            z_init_d = z_init;
            x_off = 0;
            z_off = -1;
        }

    }
        
}
