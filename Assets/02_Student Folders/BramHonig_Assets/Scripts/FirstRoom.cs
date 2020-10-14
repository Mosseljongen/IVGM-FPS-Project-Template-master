using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoom : MonoBehaviour
{
    public GameObject chamber;
    public bool[,] Walls;
    private int x_init = 10;
    private int z_init = 10;
    private int x_size = 4;
    private int z_size = 4;
    // Start is called before the first frame update
    void Start()
    {
        Walls = new bool[200, 200];

        GameObject fR = Instantiate(chamber, new Vector3(0, 0, 0), Quaternion.identity);
        fR.GetComponent<Chamber>().Initialise(4, 4, 1,transform.position.x, transform.position.y,
            transform.position.z - 1,ref Walls, x_init, z_init,0);

    }

    // Update is called once per frame
   
}
