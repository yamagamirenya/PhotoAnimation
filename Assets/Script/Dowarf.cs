﻿using UnityEngine;
using System.Collections;

public class Dowarf : MonoBehaviour {

    public GameObject 
        origami1, 
        FallPhoto;

    Animator 
        _animator;

    bool finishRiding = true;

    // Use this for initialization
    void Start () {

        _animator = GetComponent<Animator>();
    
    }
    
  
    
    void Update()
    {

        AnimationWithPhoto();
        AnimationWithOrigami();

    }

    void AnimationWithPhoto()
    {

        if (FallPhoto)
        {
            if (FallPhoto.activeInHierarchy)
            {

                _animator.SetBool("Riding", true);
            }
        }
        else
        {
            if(finishRiding)
            _animator.SetBool("Riding", false);
        }

    }

    void AnimationWithOrigami()
    {
        if (origami1)
        {
            if (origami1.activeInHierarchy)
            {
                finishRiding = false;
                _animator.SetBool("Riding", true);

            }
        }
    }    

        
}


   
