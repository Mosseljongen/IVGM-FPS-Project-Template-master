using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoom : MonoBehaviour
{
    public GameObject chamber;
    public GameObject ob;
    public bool[,] Walls;
    private int x_init = 100;
    private int z_init = 100;
    private int x_size = 4;
    private int z_size = 4;
    public int doors_placed = 0;
    private int Rooms_dest = 4;
    // Start is called before the first frame update
    void Start()
    {
        var me = this;
        Walls = new bool[200, 200];

        GameObject fR = Instantiate(chamber, new Vector3(0, 0, 0), Quaternion.identity);
        fR.GetComponent<Chamber>().Initialise(4, 4, 1,(int)transform.position.x, (int)transform.position.y,
            (int)transform.position.z - 1,ref Walls, x_init - 4, z_init,0,Rooms_dest, ref me);

    }

    // Update is called once per frame
   
}
