using UnityEngine;
using System.Collections;

public class Doo : MonoBehaviour
{

    private bool doorOpen = false;
    private bool doorOpened = false;
    private Ray ray;
    private RaycastHit hit;
    private float distance = 5.0f;
    public GameObject chamber;
    public GameObject G;
    public  FirstRoom firstRoom;
    public bool[,] Walls;
    private int x_init_d;
    private int z_init_d;
    private int z_off;
    private int x_off;
    private int side_d;
    private int dest;

    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, distance))
            {
                string a  = hit.collider.transform.root.name;
                string b  = gameObject.name;

                Debug.Log("Text: " + a + " " + b + hit.collider.transform.parent);
                if (a == b)
                {
                    Debug.Log("waar is de kamer"+ doorOpen+' '+ doorOpened);
                    if (!doorOpen)
                    {
                        if (!doorOpened)
                        {
                            Debug.Log("Text: " + side_d + " " + gameObject.name);
                            GameObject chamber_ins = Instantiate(chamber, new Vector3(0, 0, 0), Quaternion.identity);
                            chamber_ins.GetComponent<Chamber>().Initialise(4, 4, 1, (int)transform.position.x + x_off, (int)transform.position.y, (int)transform.position.z + z_off,
                                ref Walls, x_init_d, z_init_d, side_d, dest, ref firstRoom);
                            doorOpened = true;
                        }
                            //Quaternion targetRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                        //hit.transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, 2.0f);

                        doorOpen = true;
                        Destroy(gameObject);
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
    public void Initialise(ref bool[,] taken, int x_init, int z_init,int side,int Rooms_dest, ref FirstRoom inst)
    {
        firstRoom = inst;
        dest = Rooms_dest;
        side_d = side;
        Walls = taken;
        if (side == 0) {
            x_init_d = x_init;
            z_init_d = z_init;
            x_off = 0;
            z_off = -1;
        }
        if (side ==1) {
            x_init_d = x_init ;
            z_init_d = z_init;
            x_off = -1;
            z_off = 0;
        }
        if (side == 2)
        {
            x_init_d = x_init ;
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
        

    }
        
}
