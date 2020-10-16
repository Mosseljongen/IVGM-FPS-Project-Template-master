// Instantiates 10 copies of Prefab each 2 units apart from each other

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chamber : MonoBehaviour
{
    public GameObject Wall;
    public GameObject enemy;
    public GameObject Floor;
    public GameObject Entrance;
    public GameObject DoorOpen;
    public FirstRoom firstRoom;
    public bool[,] Walls;
    public bool[,] newFloors;
    private float width = 2F;
    private float depth = 2F;
    private int height = 3;
    private int number_enemies ;
    private int Rooms_dest;


    // This script will simply instantiate the Prefab when the game starts.
    public void Start()
    {

    }
public void Initialise(int width_r ,int depth_r, int height_r, int pos_x, int pos_y, int pos_z, ref bool[,] taken
    ,int x_init,int  z_init,int side,int dest, ref FirstRoom inst)
    {
        //A
        firstRoom = inst;
        Rooms_dest = dest;
        Debug.Log("Goal room: " + Rooms_dest );
        Walls = taken;

        int izA =0;
        int izC =0;
        int ixB=0;
        int ixD=0 ;
        int izA2 = 0;
        int izC2 = 0;
        int ixB2 = 0;
        int ixD2 = 0;
        int pos_door;
        int side_dest = Random.Range(0, 3);
        while (side_dest == side) {
            side_dest = Random.Range(0, 3);
        }
        if (dest == 4)
            number_enemies = 0;
        else
            number_enemies = Random.Range(0, 2);
        newFloors = new bool[200, 200];
        if (side == 0) {
            x_init = x_init + width_r;
            z_init = z_init;
            ixB = x_init -1;
            ixD = x_init + width_r;
            ixB2 = x_init ;
            ixD2 = x_init + width_r - 1;
            izA = z_init - 1;
            izC = z_init + depth_r;
            izA2 = z_init;
            izC2 = z_init + depth_r - 1;

        }
        if (side == 1) {
            x_init = x_init;
            z_init = z_init + depth_r;
            izA = z_init -1;
            izC = z_init + depth_r;
            izA2 = z_init ;
            izC2 = z_init + depth_r - 1;
            ixB = x_init - 1;
            ixD = x_init + width_r;
            ixB2 = x_init;
            ixD2 = x_init + width_r - 1;

        }
        if (side == 2) {
            x_init = x_init - width_r;
            z_init = z_init;
            ixB = x_init - 1;
            ixD = x_init + width_r;
            ixB2 = x_init;
            ixD2 = x_init + width_r - 1;
            izA = z_init - 1;
            izC = z_init + depth_r;
            izA2 = z_init;
            izC2 = z_init + depth_r - 1;

        }
        if (side == 3) {
            x_init = x_init;
            z_init = z_init - depth_r;
            izA = z_init - 1;
            izC = z_init + depth_r; 
            izA2 = z_init;
            izC2 = z_init + depth_r -1;
            ixB = x_init - 1;
            ixD = x_init + width_r;
            ixB2 = x_init;
            ixD2 = x_init + width_r - 1;

        }
                       
        //ceiling and floor
        for (int x = 0; x < width_r; x++) // Width
        {
            for (int z = 0; z < depth_r; z++) // Depth
            {
                if (!Walls[x_init + x, z_init + z])
                {
                    newFloors[x_init + x, z_init + z] = true;
                    Instantiate(Floor, new Vector3(pos_x + x * width + 1, pos_y, pos_z + z * depth + 1), Quaternion.identity);
                    Instantiate(Floor, new Vector3(pos_x + x * width + 1, pos_y + height_r * height, pos_z + z * depth + 1), Quaternion.Euler(180, 0, 0));
                    Instantiate(Floor, new Vector3(pos_x + x * width + 1, pos_y + height_r * height, pos_z + z * depth + 1), Quaternion.identity);
                    Walls[x_init + x, z_init + z] = true;
                    if (Random.Range(0, depth_r * width_r) < number_enemies) {
                        Instantiate(enemy, new Vector3(pos_x + x * width + 1, pos_y + 1, pos_z + z * depth + 1), Quaternion.identity);
                    }
                    
                }

            }
        }
       
        if (Rooms_dest == 0) {
            GameObject[] goal = GameObject.FindGameObjectsWithTag("Objective");
            Debug.Log(goal[0].transform.position);
            Debug.Log(goal[0].name);
            goal[0].transform.position = new Vector3(pos_x + 2 * width + 1, 0, pos_z + 2 * depth + 1);
            //Instantiate(Wall, new Vector3(pos_x + 2 * width + 1, pos_y + 1, pos_z + 2 * depth + 1), Quaternion.Euler(0, 0, 0));
            //goal[0].GetComponent<Pickup>().m_StartPosition = new Vector3(pos_x + 2 * width + 1, 5, pos_z + 2 * depth + 1);
            Debug.Log(goal[0].transform.position);

            //Debug.Log("final room: "+ firstRoom.ob.transform.Find("Objective_pick").transform.position);
            //firstRoom.ob.transform.Find("Objective_pick").transform.position = new Vector3(pos_x + 2 * width + 1, pos_y + 1, pos_z + 2 * depth + 1);
            
            //Instantiate(Goal, new Vector3(pos_x + 2 * width + 1, pos_y + 1, pos_z + 2 * depth + 1), Quaternion.identity);
            //Instantiate(Dest, new Vector3(pos_x + 2 * width + 1, pos_y + 1, pos_z + 2 * depth + 1), Quaternion.identity);
            //Debug.Log("final room: " + firstRoom.ob.transform.Find("Objective").transform.position);
        }

        //D B

        for (int y = 0; y < height_r; y++) // height
        {
            pos_door = 0;//Random.Range(0, depth_r - 1);
            for (int z = 0; z < depth_r; z++)// Depth
            {
                //B
                if (Walls[ixB, z_init + z] ^ newFloors[ixB2, z_init + z])//)
                {
                    if (pos_door == z && Rooms_dest > 0)
                    {
                        Debug.Log("door1: " );//door[2] = 
                        Instantiate(Entrance, new Vector3(pos_x, pos_y + y * height, pos_z + z * depth + 1), Quaternion.Euler(0, 90, 0));
                        GameObject door_temp = Instantiate(DoorOpen, new Vector3(pos_x, pos_y + y * height, pos_z + z * depth + 1), Quaternion.Euler(0, 90, 0));
                        door_temp.name = firstRoom.doors_placed.ToString();
                        door_temp.GetComponent<Doo>().Initialise(ref Walls, x_init, z_init + z, 2, (side_dest == 2) ? Rooms_dest - 1 : -1, ref inst);
                        firstRoom.doors_placed++;

                    }
                    else
                        Instantiate(Wall, new Vector3(pos_x, pos_y + y * height, pos_z + z * depth + 1), Quaternion.Euler(0, 90, 0));
                }
                else if (side_dest == 2) side_dest = 0;
                //D
                
                if ( Walls[ixD, z_init + z  ]^ newFloors[ixD2, z_init + z])
                {
                    if (pos_door == z && Rooms_dest > 0)
                    {
                        //door[0] = 
                        Instantiate(Entrance, new Vector3(pos_x + width * width_r, pos_y + y * height, pos_z + z * depth + 1), Quaternion.Euler(0, 90, 0));
                        GameObject door_temp = Instantiate(DoorOpen, new Vector3(pos_x + width * width_r, pos_y + y * height, pos_z + z * depth + 1), Quaternion.Euler(0, 90, 0));
                        door_temp.name = firstRoom.doors_placed.ToString();
                        door_temp.GetComponent<Doo>().Initialise(ref Walls, x_init, z_init + z, 0, (side_dest == 0) ? Rooms_dest - 1 : -1, ref inst);
                        firstRoom.doors_placed++;
                    }
                    else
                       Instantiate(Wall, new Vector3(pos_x + width * width_r, pos_y + y * height, pos_z + z * depth + 1), Quaternion.Euler(0, 90, 0));
                }
                else if (side_dest ==0) side_dest = 3;

            }
        }
 

        //A C
        for (int y = 0; y < height_r; y++)// Hight
        {
            pos_door = 0;// Random.Range(0, width_r - 1);
            for (int x = 0; x < width_r; x++) // Width
            {

                //A
                if (Walls[x_init + x, izA] ^ newFloors[x_init + x, izA2])
                {
                    if (pos_door == x && Rooms_dest > 0)
                    {

                        Instantiate(Entrance, new Vector3(pos_x + x * width + 1, pos_y + y * height, pos_z), Quaternion.Euler(0, 0, 0));
                        GameObject door_temp = Instantiate(DoorOpen, new Vector3(pos_x + x * width + 1, pos_y + y * height, pos_z), Quaternion.Euler(0, 0, 0));
                        door_temp.name = firstRoom.doors_placed.ToString();
                        door_temp.GetComponent<Doo>().Initialise(ref Walls, x_init + x, z_init, 3, (side_dest == 3) ? Rooms_dest - 1 : -1, ref inst);

                        firstRoom.doors_placed++;
                    }
                    else
                        Instantiate(Wall, new Vector3(pos_x + x * width + 1, pos_y + y * height, pos_z), Quaternion.Euler(0, 0, 0));
                }
                else if (side_dest == 3) side_dest = 1;
                //C
                if ( Walls[x_init + x, izC] ^ newFloors[x_init + x, izC2])
                {


                    if (pos_door == x && Rooms_dest > 0)
                    {
                        Instantiate(Entrance, new Vector3(pos_x + x * width + 1, pos_y + y * height, pos_z + depth_r * depth), Quaternion.Euler(0, 0, 0));
                        GameObject door_temp = Instantiate(DoorOpen, new Vector3(pos_x + x * width + 1, pos_y + y * height, pos_z + depth_r * depth), Quaternion.Euler(0, 0, 0));
                        door_temp.name = firstRoom.doors_placed.ToString();
                        door_temp.GetComponent<Doo>().Initialise(ref Walls, x_init + x, z_init, 1, (side_dest == 1) ? Rooms_dest - 1 : -1, ref inst);

                        firstRoom.doors_placed++;
                    }
                    else
                        Instantiate(Wall, new Vector3(pos_x + x * width + 1, pos_y + y * height, pos_z + depth_r * depth), Quaternion.Euler(0, 0, 0));

                }


            }
        }


    }
}

