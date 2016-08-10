using UnityEngine;
using System.Collections;

public class Choke : MonoBehaviour {

    public GameObject textMask;
    private Material imageMaterial,
                     textMaskMaterial;
   
    float n;
	// Use this for initialization
	void Start () {

        imageMaterial = this.gameObject.GetComponent<Renderer>().material;
        textMaskMaterial = textMask.GetComponent<Renderer>().material;
        n = 0;
        print(imageMaterial);
	}
	
	// Update is called once per frame
	void Update () {

        n += Time.deltaTime;

        imageMaterial.SetFloat("_Flip", n*0.5f-1);
        textMaskMaterial.SetFloat("_Flip", 1 - n * 0.5f);

	}
}
