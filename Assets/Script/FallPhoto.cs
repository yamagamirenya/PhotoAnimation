using UnityEngine;
using System.Collections;
using System;

public class FallPhoto : MonoBehaviour {

    public bool picture_animation = false;
    public Color alpha = new Color(0, 0, 0, 0.01f);

    void Picture_Animation()
    {
        if (picture_animation)
        {
            Console.Write("fvafa");
            GetComponent<Renderer>().material.color -= alpha;
            GameObject.Find("PictureParticle").SetActive(true);
        }
    }

    void Update () {

        transform.position = this.transform.position
                                       - new Vector3(0, 0.03f, Mathf.Sin(Time.time) * 0.01f);

        Picture_Animation();
	}

    void OnCollisionEnter(Collision other){
        picture_animation = true;
    }

    

}
