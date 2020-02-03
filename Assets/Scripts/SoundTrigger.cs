using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public bool Once;
    public float Lifetime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            GetComponent<AudioSource>().Play();
            if (Once) {
                GetComponent<Collider>().enabled = false;
                Destroy(gameObject,Lifetime);
            }
        }
    }
}
