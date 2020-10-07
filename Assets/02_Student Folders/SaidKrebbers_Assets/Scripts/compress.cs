using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compress : MonoBehaviour
{
  private bool depressing = false;
  private bool pressing = false;
  private bool pressed = false;
  private float speed = 0.2f;
  private float speed2 = 5;
  private float timer = 1f;
  private float timer2 = 1f;
  public Vector3 startPosition;
  public Vector3 endPosition;
  public Vector3 weaponEndPosition;
  private bool activated = false;
  private bool done = false;

  public Transform button;
  public Transform weaponDoor;
  public Collider triggerZone;



  // Start is called before the first frame update
  void Start()
  {
    pressing =false;
    depressing = false;
    pressed = false;
    // depressed = true;
  }

  // Update is called once per frame
  void Update()
  {
      if(pressing && timer > 0){
        button.Translate(Vector3.down * Time.deltaTime * speed);
        timer -= Time.deltaTime;
      }
      else if(depressing && timer > 0){
        button.Translate(Vector3.up * Time.deltaTime * speed);
        timer -= Time.deltaTime;
      }
      if(activated && timer2 > 0 && !done){
        weaponDoor.Translate(Vector3.down * Time.deltaTime * speed2);
        timer2 -= Time.deltaTime;
      }


      if(timer <= 0){
        if(pressing){
          pressed = true;
          pressing = false;
          button.position = endPosition;
          //move weapon
          if(!done)
            activated = true;
        }
        if(depressing){
          pressed = false;
          depressing = false;
          button.position = startPosition;
        }
      }
      if(timer2 < 0){
        done = true;
      }
  }

  void OnTriggerEnter(Collider other){
    if(pressed){
      //do nothing
      return;
    }
    if(depressing){
      timer = 1-timer;
      depressing = false;
      pressing = true;
    }
    else{
      timer = 1f;
      pressing = true;
    }
  }

  void OnTriggerExit(Collider other){
    if(pressing){
      timer = 1-timer;
      depressing = true;
      pressing = false;
      pressed = false;
    }
    else if(depressing){
      //do nothing
      pressed = false;
    }
    else if(pressed){
      timer = 1f;
      depressing = true;
      pressed = false;
    }
    else{
      //do nothing
    }
  }
}
