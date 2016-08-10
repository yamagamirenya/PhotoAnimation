using UnityEngine;
using System.Collections;

public class DowarfPhoto : MonoBehaviour {

    public GameObject 
        FallPhoto, 
        japonicaNote,
        japonica,
        origami1;

    bool 
        jump =true,
        changeRotation,
        changeRotation2=true,
        lookUp;

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
        if (!lookUp)
        {
            JampAction();
        }
        else
        {
            LookUpAction();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        jump = false;
        lookUp = true;

        _animator.SetBool("Jamp", false);

        if(other.gameObject == japonica)
        {
            jump = false;
        }
    }

    void DowarfRandomJampAction()
    {
     
            toDowarfpositionZ = 1.2f;

    }

    void JampAction()
    {
        if (fallphoto!= null)
        {
            if (fallphoto.nextFallPhotoActiom)
            {
                if (jump)
                {
                    n += Time.deltaTime;


                    if (!this.gameObject.GetComponent<BoxCollider>())
                    {
                        this.gameObject.AddComponent<BoxCollider>();

                       // this.gameObject.GetComponent<BoxCollider>().size = new Vector3 ()
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
    }

    void LookUpAction()
    {
        
                _animator.SetBool("LookUp", true);
        if (changeRotation2)
        {
            transform.rotation =Quaternion.Euler(0, 90, 0);
            changeRotation2 = false;
        }
        

    }
    
   

}
