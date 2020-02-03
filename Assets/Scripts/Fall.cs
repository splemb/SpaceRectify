using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall : MonoBehaviour
{
    public Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position + new Vector3(0,2,0);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20){
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
