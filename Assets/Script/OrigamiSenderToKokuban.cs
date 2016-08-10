using UnityEngine;
using System.Collections;

public class OrigamiSenderToKokuban : MonoBehaviour {

    public GameObject 
        origami3,
        appearPoint1,
        appearPoint2,
        appearPoint3,
        appearPoint4;

    float 
        n,
        firstOrigamiPositionZ;

    Vector3 appearPoint;

    Quaternion quaternion;


    // Use this for initialization
    void Start () {
        firstOrigamiPositionZ = this.transform.position.z;

	}
	
	// Update is called once per frame
	void Update () {


        AppearPointChanger();

        n += Time.deltaTime;

        this.transform.position = new Vector3(this.transform.position.x,
            this.transform.position.y, firstOrigamiPositionZ + 5*Mathf.Sin(n * 0.1f));

        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Instantiate(origami3, appearPoint, Quaternion.identity);

            
        }

	}


     void AppearPointChanger()
    {

        if (Random.value < 0.25f)
        {
            appearPoint = appearPoint1.transform.position;
        }
        else if (Random.value > 0.25f && Random.value < 0.5f)
        {
            appearPoint = appearPoint2.transform.position;
          quaternion = Quaternion.Euler(270, 270, 270);

        }
        else if (Random.value > 0.5f && Random.value < 0.75f)
        {
            appearPoint = appearPoint3.transform.position;
            quaternion = Quaternion.Euler(270, 270, 270);

        }
        else if (Random.value > 0.75f && Random.value < 1f)
        {
            appearPoint = appearPoint4.transform.position;
            quaternion = Quaternion.Euler(270, 270, 270);

        }
        else
        {
            appearPoint = appearPoint4.transform.position;
            quaternion = Quaternion.Euler(270, 270, 270);

        }
    }
}
