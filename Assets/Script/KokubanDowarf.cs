using UnityEngine;
using System.Collections;

public class KokubanDowarf : MonoBehaviour {

    public GameObject chokeText;
    Animator _animator;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (chokeText.activeInHierarchy)
        {
            _animator.SetBool("Writing", true);
           
        }

        
	}
}
