using UnityEngine;
using System.Collections;
using System;

public class FallPhoto : MonoBehaviour {

    public GameObject
       paperPhoto,
       FallParticleSystem,
       origami3;

 

    public bool
        move = true,
        nextFallPhotoActiom,
        japonicaAction;

   

    public float 
        t = 0,
            d;

    Vector3
          firstPosition;

    public float
        moveSpeed;

    Material 
        fallPhotoMaterial,
        notePhotoMaterial;


    void Start()
    {

        fallPhotoMaterial = GetComponent<Renderer>().material;
        notePhotoMaterial = paperPhoto.GetComponent<Renderer>().material;

        fallPhotoMaterial.SetFloat("_Alpha", 1);
        firstPosition = transform.position;


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
                                    - new Vector3(0, moveSpeed*0.02f, d);

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
                japonicaAction = true;
                nextFallPhotoActiom = false;
                
                d = 0;

                this.gameObject.transform.position = firstPosition;
                this.gameObject.SetActive(false);
                FallParticleSystem.SetActive(false);
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
