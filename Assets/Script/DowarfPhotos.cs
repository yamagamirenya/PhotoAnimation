using UnityEngine;
using System.Collections;

public class DowarfPhotos : MonoBehaviour {


    public GameObject fallPhoto;
   
    
    void Update()
    {

        if (fallPhoto != null)
        {
            float d = Mathf.Sin(Time.time) * 0.01f;
            transform.position = this.transform.position - new Vector3(0, 0.02f, d);
        }
    }
 }







    




    




    

    

