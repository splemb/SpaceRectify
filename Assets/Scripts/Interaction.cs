using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject lookingAt;
    public int materialCount;
    public GameObject repairParticleBeam;
    public GameObject destroyParticleBeam;
    public Transform cannonPos;
    public int lookingAtCount = 0;
    public int lookingAtMax = 0;

    // Start is called before the first frame update
    void Start()
    {
        materialCount = Globals.globalMaterialCount;
    }

    // Update is called once per frame
    void Update()
    {
        GetLookingAt();

        if (lookingAt.tag == "Interact") {
            lookingAtCount = lookingAt.GetComponent<Broken>().currentMaterials;
            lookingAtMax = lookingAt.GetComponent<Broken>().requiredMaterials;
        } else {
            lookingAtCount = 0;
            lookingAtMax = 0;
        }

        if (Input.GetMouseButton(0)) {
            if (lookingAt.tag == "Interact" && lookingAt.GetComponent<Broken>().broken) {
                if (materialCount != 0) {
                    MakeBeam(false);
                    materialCount--;
                    lookingAt.GetComponent<Broken>().currentMaterials ++;
                }
            }
        }

        if (Input.GetMouseButton(1)) {
            if (lookingAt.tag == "Interact"){
                if (lookingAt.GetComponent<Broken>().currentMaterials != 0) {
                    MakeBeam(true);
                    materialCount++;
                    lookingAt.GetComponent<Broken>().currentMaterials --;
                }
            }
        }

        Globals.globalMaterialCount = materialCount;
    }

    private void GetLookingAt()
    {
        RaycastHit hit;
        Debug.DrawRay(cannonPos.position, cannonPos.forward, Color.white);
        if (Physics.Raycast(cannonPos.position, cannonPos.forward, out hit, 10))
        {
           lookingAt = hit.transform.gameObject;
        } else
        {
            lookingAt = null;
        }
    }

    private void MakeBeam(bool destroy) {
        float step = 1f / 10;
                float currentStep = 0;
                Vector3 Position = new Vector3();
                for( int i = 0; i < 5; i++ )
                {
                    currentStep += step;
                    Position = Vector3.Lerp(cannonPos.position, lookingAt.transform.position, currentStep);
                    if (destroy) {
                        Instantiate(destroyParticleBeam, Position, Quaternion.identity);
                    } else {
                        Instantiate(repairParticleBeam, Position, Quaternion.identity);
                    }
                }
    }
}
