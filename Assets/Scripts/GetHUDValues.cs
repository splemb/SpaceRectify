using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Globals
{
       public static int globalMaterialCount = 100;
}

public class GetHUDValues : MonoBehaviour
{

    public Interaction player;
    public Text materialDisplay;
    public Text materialText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        materialDisplay.text = player.materialCount.ToString();
        materialText.text = (player.lookingAtCount.ToString() + " / " + player.lookingAtMax.ToString());

        if (player.lookingAtMax == 0) {
            materialText.enabled = false;
        } else {
            materialText.enabled = true;
        }
    }
}
