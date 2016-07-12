using UnityEngine;
using System.Collections;

public class Japonica : MonoBehaviour {

    public GameObject JaponicaAngle;

    public bool open = false;

    public float d = 0;
	// Use this for initialization
	void Start () {
       

	}
	
	// Update is called once per frame
	void Update () {

          d += 45 * Time.deltaTime;

        if(d>100&&d<180+100)
            transform.RotateAround(JaponicaAngle.transform.position, new Vector3(-1,0,-1), 45 * Time.deltaTime);
    
	}
}
