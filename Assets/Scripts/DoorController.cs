using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;
    public AudioSource[] doorSounds = new AudioSource[2];

    public float closeTime;
    public float closeTimer = 0;

    public bool open = false;
    public bool inTrigger = false;

    public bool Locked;

    private bool broken;

    void Start()
    {
        

        if (broken) {
            GetComponent<BoxCollider>().enabled = false;
        }

        if (Locked) {
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        broken = GetComponent<Broken>().broken;
        anim.SetBool("Open",open);
        anim.SetBool("Broken",broken);


        if (!inTrigger) {
            if (closeTimer <= 0f) {
                closeTimer = 0f;
                
                if (open == true) {            
                    doorSounds[0].Play();
                    open = false;
                }
            } else {
                closeTimer -= Time.deltaTime;
            }
        }

        if (!broken && !Locked) {
            GetComponent<BoxCollider>().enabled = true;
        }
        else if (broken || Locked) {
            GetComponent<BoxCollider>().enabled = false;
        }

        if (broken) {
            open = false;
        }

    }

    private void OnTriggerEnter(Collider other){
        if (other.tag == "Player" && !open) {
            open = true;
            inTrigger = true;
            doorSounds[0].Play();
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.tag == "Player") {
            closeTimer = closeTime;
            inTrigger = false;
        }
    }
}
