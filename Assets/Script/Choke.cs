using UnityEngine;
using System.Collections;

public class Choke : MonoBehaviour {

    private Material material;
    float n;
	// Use this for initialization
	void Start () {

        material = this.gameObject.GetComponent<Renderer>().material;
        n = 0;
        print(material);
	}
	
	// Update is called once per frame
	void Update () {

        n += Time.deltaTime;

        material.SetFloat("_Flip", n*0.5f-1);


	}
}
