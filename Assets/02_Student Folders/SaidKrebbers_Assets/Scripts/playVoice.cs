using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playVoice : MonoBehaviour
{
    public Collider triggerZone;
    public AudioSource audio;
    private bool triggered;
    // Start is called before the first frame update
    void Start()
    {
      triggered = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(){
      if(!triggered){
        triggered = true;
        audio.Play();
      }
    }
}
