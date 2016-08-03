using UnityEngine;
using System.Collections;

public class DowarfPhoto : MonoBehaviour {

    public GameObject 
        FallPhoto, 
        japonicaNote;

    bool 
        jump =true,
        changeRotation;

    float
        n = 0,
        toDowarfpositionZ;

    Vector3 firstDowarfPosition;


    FallPhoto fallphoto;

    Animator _animator;

    // Use this for initialization
    void Start () {

        _animator = GetComponent<Animator>();
        fallphoto = FallPhoto.GetComponent<FallPhoto>();
      
        DowarfRandomJampAction();

        firstDowarfPosition = this.transform.position;
	}


	
	void Update () {

        JampAction();

        LookUpAction();

    }

    void OnCollisionEnter(Collision other)
    {
        jump = false;
        _animator.SetBool("Jamp", false);

    }


    void DowarfRandomJampAction()
    {

        if (Random.value < 0.5f)
        {
            toDowarfpositionZ = -5;
            changeRotation = true;
        }
        else
        {
            toDowarfpositionZ = 1.2f;
        }

    }

    void JampAction()
    {
        if (fallphoto.nextFallPhotoActiom)
        {
            if (jump)
            {
                n += Time.deltaTime;


                if (!this.gameObject.GetComponent<BoxCollider>())
                {
                    this.gameObject.AddComponent<BoxCollider>();
                }


                _animator.SetBool("Jamp", true);

                if (changeRotation)
                {
                    transform.Rotate(0, 180, 0);
                }

                changeRotation = false;

                transform.parent = null;

                //Dowarf can jamp to below popsition 
                transform.position = new Vector3(this.transform.position.x + Random.Range(0, 1),

                                            this.transform.position.y + (0.5f * n - 0.5f * 0.98f * n * n) * 0.5f,

                                            firstDowarfPosition.z + (3 + toDowarfpositionZ * 1.35f) * n);


            }
        }
    }

    void LookUpAction()
    {

        if (japonicaNote != null)
        {
            if (japonicaNote.transform.position.y >= 3.5f)
            {
                _animator.SetBool("LookUp", true);

                transform.Rotate(0, -180, 0);


            }
        }

    }
    
   

}
