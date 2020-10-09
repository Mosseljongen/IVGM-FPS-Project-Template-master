using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class breakOnTouch : MonoBehaviour
{
    [Tooltip("If true enemies that have a rigidbody can also trigger this.")]
    public bool enemyTrigger = false;
    bool destroyed = false;
    bool destroying = false;
    bool actuallyDestroyed = false;
    float timer;
    [Tooltip("How long it will take for the effect to happen once activated.")]
    public float delay = 0.5f;
    Collider boxCollider;
    Renderer renderer;
    MeshCollider floorMesh;

    public AudioSource SoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<Collider>();
        renderer = GetComponent<Renderer>();
        floorMesh = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (destroying)
        {
            timer -= Time.deltaTime;
            UnityEngine.Debug.Log("reducing time");
        }
        
        if (!actuallyDestroyed && destroying && timer < 0f)
        {
            renderer.enabled = false;
            floorMesh.enabled = false;
            actuallyDestroyed = true;
            destroying = false;
            UnityEngine.Debug.Log("boom item should be gone");
            SoundEffect.Play();
        }
        

    }

    void OnTriggerEnter (Collider other)
    {
        PlayerCharacterController player = other.GetComponent<PlayerCharacterController>();
        Damageable enemy = other.GetComponent<Damageable>();

        if (player == null && !enemyTrigger) return;
        if (enemyTrigger)
        {
            if (enemy == null)
            {
                UnityEngine.Debug.Log("no enemy found");
                return;
            }
        }
        

 
       UnityEngine.Debug.Log("player was recognized");
       if (!destroyed)
       {                
            destroying = true;
            destroyed = true;
            timer = delay;
       }

      
    }
}   
