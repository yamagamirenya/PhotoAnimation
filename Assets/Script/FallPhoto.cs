using UnityEngine;
using System.Collections;
using System;

public class FallPhoto : MonoBehaviour {

    public GameObject
       paperPhoto,
       FallParticleSystem;

    bool
        move = true;

    public bool
        nextFallPhotoActiom;

    float
        d,
        t = 0;

    Material 
        fallPhotoMaterial,
        notePhotoMaterial;


    void Start()
    {

        fallPhotoMaterial = GetComponent<Renderer>().material;
        notePhotoMaterial = paperPhoto.GetComponent<Renderer>().material;

    }


    public void Update () {


        FallPhotoMove();

        NextFallPhotoAction();

	}

    void OnCollisionEnter(Collision other)
    {
        move = false;
        paperPhoto.SetActive(true);
        nextFallPhotoActiom = true;

    }

    void FallPhotoMove()
    {
        if (move)
        {
            d = Mathf.Sin(Time.time) * 0.01f;
            transform.position = this.transform.position
                                    - new Vector3(0, 0.02f, d);

        }
        else
        {
            transform.position = this.transform.position
                                   - new Vector3(0, 0, 0);
        }

    }

    void NextFallPhotoAction()
    {
        if (nextFallPhotoActiom)
        {

            this.GetComponent<Collider>().enabled = false;
            FallParticleSystem.SetActive(true);


            MaterialAToBAlphaSender(fallPhotoMaterial, notePhotoMaterial);


            if (1 - t * 0.1f < 0)
            {

                nextFallPhotoActiom = false;
                Destroy(this.gameObject);

            }

        }

    }

    //Below is in upper Object (NextFallPhotoAction)
    void MaterialAToBAlphaSender(Material A,Material B)
    {
        t += Time.deltaTime;

        A.SetFloat("_Alpha", 1 - t * 0.1f);
        B.SetFloat("_Alpha", t * 0.1f);


    }


}
