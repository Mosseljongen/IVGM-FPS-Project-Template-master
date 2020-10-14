using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallArray : MonoBehaviour
{
    // Start is called before the first frame update
    public bool[,] Walls = new bool[20, 20];
    void Start()
    {
        Walls[10,10] = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
