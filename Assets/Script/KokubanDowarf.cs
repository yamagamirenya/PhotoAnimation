using UnityEngine;
using System.Collections;

public class KokubanDowarf : MonoBehaviour {

    public GameObject 
        chokeText,
        chokeTextMask,
        origami3;

    Animator _animator;

    Vector3 firstPostion;

    float
        n = 0;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
        firstPostion = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (chokeText.activeInHierarchy)
        {
            _animator.SetBool("Writing", true);

            chokeDowarfMove();
        }

        FinishAndFirst();

    }


    void chokeDowarfMove()
    {
        n += Time.deltaTime;
        Vector3 dowarfLastPosition = chokeTextMask.transform.position;

        transform.position = 
            new Vector3(Mathf.Lerp(this.transform.position.x, dowarfLastPosition.x, n),
                        Mathf.Lerp(this.transform.position.y, dowarfLastPosition.y, n), 
                        Mathf.Lerp(this.transform.position.z, dowarfLastPosition.z, n));
    }

    void FinishAndFirst()
    {
        Origami3 origami3Script = origami3.GetComponent<Origami3>();

        if (origami3Script.blurOptimizedChange == true)
        {
            this.transform.position = firstPostion;

            n = 0;
        }



    }
}
