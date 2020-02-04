using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public bool Once;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Collider>().enabled && !GetComponent<AudioSource>().isPlaying)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            GetComponent<AudioSource>().Play();
            if (Once) {
                GetComponent<Collider>().enabled = false;
            }
        }
    }
}
