using UnityEngine;
using System.Collections;

public class OrigamiManeger : MonoBehaviour {













   //Tukattenaidesu






















    public GameObject origami3;
    public GameObject AppearObject;
    public GameObject hikouki;
 
    // Use this for initialization
    void Start () {



    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown("right"))
        {
            Instantiate(origami3, AppearObject.transform.position, Quaternion.identity);
            hikouki = Instantiate(origami3, AppearObject.transform.position, Quaternion.identity) as GameObject;
        }
    }
}
