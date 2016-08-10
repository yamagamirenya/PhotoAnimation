using UnityEngine;
using System.Collections;

public class KokubanChokeManeger : MonoBehaviour
{

    public GameObject
        chokeImage,
        chokeTextMask;

    private Material 
        chokeImageMaterial,
        textMaskMaterial;

    float n=0;

    Origami3 origami3Script;
    // Use this for initialization
    void Start()
    {

        chokeImageMaterial = chokeImage.GetComponent<Renderer>().material;
        textMaskMaterial = chokeTextMask.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
                n += Time.deltaTime;
                print("aaaa");
                chokeImageMaterial.SetFloat("_Flip", n * 0.5f - 1);
                textMaskMaterial.SetFloat("_Flip", 1 - n * 0.5f);
            
        
    }
}
