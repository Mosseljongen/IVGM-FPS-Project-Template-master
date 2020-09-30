using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBlockDown : MonoBehaviour
{
    public Transform wall;
    public AudioSource audio;

    private bool started = false;
    private float timer = 3f;
    private float speed = 1;
    private bool closed = false;
    private bool playing = false;
    public Collider triggerZone;
    private Vector3 endPosition = new Vector3(-37, -12, 16);

    // Start is called before the first frame update
    void Start()
    {
      // triggerZone = GetComponent<BoxCollider>();
      started = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(started && timer >10.5f){
        if(playing == false){
          playing = true;
          audio.Play();
        }
      }
      if(started && timer > 0f){
        wall.Translate(Vector3.down * Time.deltaTime * speed);
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
        timer = 11f;
      }
    }
}
