// Instantiates 10 copies of Prefab each 2 units apart from each other

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chamber : MonoBehaviour
{
    public GameObject Wall;
    public GameObject Floor;
    public GameObject Entrance;
    public GameObject Door;
    public bool[,] Walls;
    private float width = 2F;
    private float depth = 2F;
    private int height = 3;
    private int number_doors = 2;
    private List<List<int>> doors;

    // This script will simply instantiate the Prefab when the game starts.
    public void Start()
    {
      
}
public void Initialise(int width_r ,int depth_r, int height_r, float pos_x, float pos_y, float pos_z, ref bool[,] taken
    ,int x_init,int  z_init,int side)
    {
        //A
        Debug.Log("room: " + gameObject.name);
        Walls = taken;
        
        int izA =0;
        int izC =0;
        int ixB=0;
        int ixD=0 ;
        int izA2 = 0;
        int izC2 = 0;
        int ixB2 = 0;
        int ixD2 = 0;
        if (side == 0) {
            ixB = x_init - 1;
            ixD = x_init + width_r;
            ixB2 = x_init;
            ixD2 = x_init + width_r -1;
        }
        if (side == 1) {
            izC = z_init + depth_r;
            izA = z_init -1;
            izC2 = z_init + depth_r -1;
            izA2 = z_init ;
        }
        if (side == 2) {
            ixD = x_init + 1 ;
            ixB = x_init - width_r;
            ixD2 = x_init;
            ixB2 = x_init - width_r +1;
        }
        if (side == 3) {
            izA = z_init - 1;
            izC =  z_init + depth_r;
            izA2 = z_init ;
            izC2 = z_init + depth_r -1;
        }
                       
        //ceiling and floor
        for (int x = 0; x < width_r; x++) // Width
        {
            for (int z = 0; z < depth_r; z++) // Depth
            {
                Instantiate(Floor, new Vector3(pos_x + x * width + 1, pos_y, pos_z + z * depth + 1), Quaternion.identity);
                Instantiate(Floor, new Vector3(pos_x + x * width + 1, pos_y + height_r * height, pos_z + z * depth + 1), Quaternion.Euler(180, 0, 0));
                Instantiate(Floor, new Vector3(pos_x + x * width + 1, pos_y + height_r * height, pos_z + z * depth + 1), Quaternion.identity);
            }
        }

        //D B
        for (int y = 0; y < height_r; y++) // Depth
        {
            for (int z = 0; z < depth_r; z++)// Hight
            {
                //B
                if (!Walls[ixB, z+ z_init]&& !Walls[ixB2, z + z_init])
                {
                    if (Random.Range(0, width_r
                       * depth_r) < number_doors)
                    {
                        Instantiate(Entrance, new Vector3(pos_x, pos_y + y * height, pos_z + z * depth + 1), Quaternion.Euler(0, 90, 0));
                        Instantiate(Door, new Vector3(pos_x, pos_y + y * height, pos_z + z * depth + 1), Quaternion.Euler(0, 90, 0)).GetComponent<Doo>().Initialise(ref Walls, x_init, z_init + z , 2);
                    }
                    else
                        Instantiate(Wall, new Vector3(pos_x, pos_y + y * height, pos_z + z * depth + 1), Quaternion.Euler(0, 90, 0));
                }
                //D
                if (!Walls[ixD, z + z_init]&& !Walls[ixD2, z + z_init])
                {
                    if (Random.Range(0, width_r
                       * depth_r) < number_doors)
                    {
                        Instantiate(Entrance, new Vector3(pos_x + width * width_r, pos_y + y * height, pos_z + z * depth + 1), Quaternion.Euler(0, 90, 0));
                        Instantiate(Door, new Vector3(pos_x + width * width_r, pos_y + y * height, pos_z + z * depth + 1), Quaternion.Euler(0, 90, 0)).GetComponent<Doo>().Initialise(ref Walls, x_init+ width_r, z_init + z,0);
                    }
                    else
                        Instantiate(Wall, new Vector3(pos_x + width * width_r, pos_y + y * height, pos_z + z * depth + 1), Quaternion.Euler(0, 90, 0));
                }

            }
        }


        //A C
        for (int y = 0; y < height_r; y++)// Hight
        {
            for (int x = 0; x < width_r; x++) // Width
            {
                //A
                if (!Walls[x_init + x, izA]&& !Walls[x_init + x, izA2])
                {
                    if (Random.Range(0, width_r
                        * depth_r) < number_doors)
                    {
                        number_doors = number_doors - 1;
                        Instantiate(Entrance, new Vector3(pos_x + x * width + 1, pos_y + y * height, pos_z), Quaternion.Euler(0, 0, 0));
                        Instantiate(Door, new Vector3(pos_x + x * width + 1, pos_y + y * height, pos_z), Quaternion.Euler(0, 0, 0)).GetComponent<Doo>().Initialise(ref Walls, x_init + x , z_init ,3);
                    }
                    else
                        Instantiate(Wall, new Vector3(pos_x + x * width + 1, pos_y + y * height, pos_z), Quaternion.Euler(0, 0, 0));
                }
                //C
                if (!Walls[x_init + x, izC]&& !Walls[x_init + x, izC2])
                    if (Random.Range(0, width_r
                       * depth_r) < number_doors)
                    {
                        Instantiate(Entrance, new Vector3(pos_x + x * width + 1, pos_y + y * height, pos_z + depth_r * depth), Quaternion.Euler(0, 0, 0));
                        Instantiate(Door, new Vector3(pos_x + x * width + 1, pos_y + y * height, pos_z + depth_r * depth), Quaternion.Euler(0, 0, 0)).GetComponent<Doo>().Initialise(ref Walls, x_init + x, z_init + depth_r,1);
                    }
                    else
                        Instantiate(Wall, new Vector3(pos_x + x * width + 1, pos_y + y * height, pos_z + depth_r * depth), Quaternion.Euler(0, 0, 0));
            }
        }
        for (int x = x_init; x < x_init + width_r; x++)
        {
            for (int z = z_init; z < z_init + depth_r; z++)
            {
                Walls[x, z] = true;
            }

        }


    }
}

