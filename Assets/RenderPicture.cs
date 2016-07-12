using UnityEngine;
using System.Collections;

public class RenderPicture : MonoBehaviour {




   

    // Use this for initialization
    void Start () {

        
	}

    void RenderPicture_Animation()
    {
        FallPhoto fallphoto = new FallPhoto();
        if (fallphoto.picture_animation)
        {
           GameObject.Find("RenderPicture").SetActive(true);
        }

    }

    // Update is called once per frame
    void Update () {
        RenderPicture_Animation();
	}


 
}
