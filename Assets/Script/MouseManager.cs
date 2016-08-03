using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;


public class MouseManager : MonoBehaviour
{

    public GameObject 
        japonica, 
        japonicaNote, 
        origami3,
        japonicaAxis,
        camera1,
        allInputfield;

    float d = 0;

    bool openJaponica;

    Ray ray;

    RaycastHit hit;


    void Start()
    {
        ray = new Ray();
        hit = new RaycastHit();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            openJaponica = true;

            RayContorol();

            OrigamiControl();
            
        }

            JaponicaControl();
    }


    void RayContorol()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject == japonicaNote)
            {
                camera1.GetComponent<BlurOptimized>().enabled = true;
                allInputfield.SetActive(true);

            }
        }

    }

    void OrigamiControl()
    {
        if (origami3)
        {
            origami3.transform.position = new Vector3(origami3.transform.position.x, Mathf.Lerp(origami3.transform.position.y,
                                                                         4, Time.deltaTime * 0.5f), origami3.transform.position.z);
        }
    }

    void JaponicaControl()
    {
        if (openJaponica)
        {
            d += 45 * Time.deltaTime;

            if (d > 100 && d < 180 + 100)
                japonica.transform.RotateAround(japonicaAxis.transform.position, new Vector3(-1, 0, -1), 45 * Time.deltaTime);
        }
    }
}

