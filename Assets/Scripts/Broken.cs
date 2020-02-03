using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken : MonoBehaviour
{
    public int requiredMaterials;
    public int currentMaterials = 0;
    public bool broken;

    public Material normalMaterial;
    public Material ghostMaterial;

    public GameObject syncWith;

    // Start is called before the first frame update
    void Start()
    {
        if (!broken) {currentMaterials = requiredMaterials;}
        normalMaterial = GetComponent<MeshRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        if (syncWith != null) {
            currentMaterials = syncWith.GetComponent<Broken>().currentMaterials;
            broken = syncWith.GetComponent<Broken>().broken;
            requiredMaterials = syncWith.GetComponent<Broken>().requiredMaterials;
        }

        if (requiredMaterials == currentMaterials) {
            broken = false;
        } else {
            broken = true;
        }

        if (ghostMaterial != null) {
            SetMaterial();
        }
        
    }
    
    void SetMaterial() {
        if (broken) {
            GetComponent<MeshRenderer>().material = ghostMaterial;
            GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            GetComponent<Collider>().isTrigger = true;
        } else {
            GetComponent<MeshRenderer>().material = normalMaterial;
            GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            GetComponent<Collider>().isTrigger = false;
        }
    }
}
