using UnityEngine;
using System.Collections;
public class ClickAction : MonoBehaviour {


    float t;
    float firstY;

	// Use this for initialization
	void Start () {
        firstY = this.transform.position.y;
        t = 0;
	}
	
	// Update is called once per frame
	void Update () {

        t += Time.deltaTime;
         
        transform.position = new Vector3(0,firstY+0.5f*Mathf.Sin(t), 0);

        }

}

