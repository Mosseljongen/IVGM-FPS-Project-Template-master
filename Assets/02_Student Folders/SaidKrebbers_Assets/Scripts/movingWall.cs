using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingWall : MonoBehaviour
{
    public Transform wall;

    private bool started = false;
    private float timer = 3f;
    private float speed = 6;
    private bool closed = false;
    public Collider triggerZone;
    private Vector3 endPosition = new Vector3(-41, 0, 10);

    // Start is called before the first frame update
    void Start()
    {
      // triggerZone = GetComponent<BoxCollider>();
      started = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(started && timer > 0f){
        wall.Translate(Vector3.forward * Time.deltaTime * speed);
        timer = timer - Time.deltaTime;
      }
      else if(timer <= 0f && started){
        closed = true;
      }
      if(closed){
        // wall.position = endPosition;
      }
    }

    void OnTriggerEnter (Collider other){
      //set started to true
      if(!started){
        started = true;
        timer = 2.5f;
      }
    }
}
