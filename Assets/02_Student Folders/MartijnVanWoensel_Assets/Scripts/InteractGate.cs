using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractGate : MonoBehaviour
{
    
    
    [Tooltip("The new camera we want to temporarly use")]
    public Camera newCamera;
    // the old player Camera
    Camera playerCamera;
    public GameObject player;
    [Tooltip("the item you want to move around")]
    public GameObject movableObject;
    [Tooltip("the lever to show that we moved")]
    public GameObject leverHandle;
    [Tooltip("the text object we want to show once the player is close enough")]
    public GameObject text;
    [Tooltip("the duration the animination should last")]
    public float duration = 3f;
    [Tooltip("the time you want the player to wait before it starts playing the animation")]
    public float waitTimeBefore = 2f;
    [Tooltip("the time you want the player to wait after the animiation is done playing")]
    public float waitTimeAfter = 2f;
    float timer;
    float timer2;

    // posistions of the moveable object
    Vector3 originalPosition;
    Vector3 DesirtedTranslation = new Vector3(0, 2, 0);
    Transform transObject;
    Transform leverTransform;

    // keeps track of the button has been pressed
    bool buttonPressed = false;
    bool playerInHitbox = false;
    //keeps track if we are moving the movableobject
    bool moving = false;
    //keeps track if we are done moving out movableobject
    bool moved = false;
    // keeps track if we switched our cameras
    bool cameraSwitched = false;




    PlayerCharacterController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerCharacterController>();
        playerCamera = playerController.playerCamera;
        transObject = movableObject.GetComponent<Transform>();
        leverTransform = leverHandle.GetComponent<Transform>();
        originalPosition = transObject.localPosition;
        text.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0f)
        {
           
            timer -= Time.deltaTime;
            UnityEngine.Debug.Log("current value of timer: " + timer);
        }

        if (playerInHitbox)
        {
            //UnityEngine.Debug.Log("player is in hitbox");
        }
        if(playerInHitbox && Input.GetKey("e") && !buttonPressed)
        {
            buttonPressed = true;
            text.GetComponent<Renderer>().enabled = false;
            UnityEngine.Debug.Log("button was pressed");
            timer = duration + waitTimeBefore + waitTimeAfter;
        }
        if (buttonPressed && !cameraSwitched)
        {
            // turn off the player camera
            playerCamera.enabled = false;
            // turn our new camera on;
            newCamera.enabled = true;
            // update the current camera to our new desired camera position
            playerController.playerCamera = newCamera;

            // pauses updates in the playerController meaning the camera doesn't update
            playerController.paused = true;

            cameraSwitched = true;

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                go.GetComponent<WorldspaceHealthBar>().paused = true;
            }
        }
        // if half a second passed since we switched cameras
       if (cameraSwitched && timer <= duration + waitTimeAfter && !moving)
        {
            UnityEngine.Debug.Log("Moving is set to true");
            moving = true;

        }
       if (moving && timer > waitTimeAfter)
        {
            transObject.Translate(DesirtedTranslation * Time.deltaTime / duration);
        }
       if (moving && timer < waitTimeAfter && !moved)
        {
            leverTransform.Rotate(0f, 0f, -90f, Space.Self);
            transObject.localPosition = originalPosition + DesirtedTranslation;
            moving = false;
            moved = true;
        }
       if (moved &&  timer < 0f)
        {
            // turn our new camera off;
            newCamera.enabled = false;
            // turn back on the player camera
            playerCamera.enabled = true;
            
            // update the current camera to the old player camera
            playerController.playerCamera = playerCamera;

            // unpause the player
            playerController.paused = false;
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                go.GetComponent<WorldspaceHealthBar>().paused = false;
            }
        }

    }

    // checks if the player is in the hitbox
    void OnTriggerEnter(Collider other)
    {
        if(playerInHitbox) { return; }
        PlayerCharacterController player = other.GetComponent<PlayerCharacterController>();
        if (player == null) { return;}
        playerInHitbox = true;
        if (!buttonPressed) { text.GetComponent<Renderer>().enabled = true; }
        
    }
    // checks if the player is not in the hitbox anymore
    void OnTriggerExit(Collider other)
    {
        PlayerCharacterController player = other.GetComponent<PlayerCharacterController>();
        if (player == null) { return; }
        playerInHitbox = false;
        if (!buttonPressed) { text.GetComponent<Renderer>().enabled = false; }
    }
}
