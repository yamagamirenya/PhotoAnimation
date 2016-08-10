using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;


public class MouseManager : MonoBehaviour
{

    public GameObject
        japonica,
        japonicaEnd,
        japonicaNote,
        origami3,
        japonicaAxis,
        camera1,
        allInputfield,
        clickAction;

    float d = 0;

    Vector3 
        firstPosition,
        firstRotation;

    bool openJaponica;

    Ray ray;

    RaycastHit hit;



    void Start()
    {
        ray = new Ray();
        hit = new RaycastHit();

        firstPosition = japonica.transform.position;
        firstRotation = japonica.transform.localEulerAngles;
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

            FinishToFirstScean();
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
                clickAction.SetActive(false);
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


            if (d > 100 && d < 180 + 95)
            {
                japonica.transform.RotateAround(japonicaAxis.transform.position, new Vector3(-1.745f, 0, -1), 45 * Time.deltaTime);
                japonicaEnd.transform.RotateAround(japonicaAxis.transform.position, new Vector3(-1.745f, 0, -1), 45 * Time.deltaTime);
            }
        }

    }

    void FinishToFirstScean()
    {
        Origami3 origami3Script = origami3.GetComponent<Origami3>();

       if( origami3Script.blurOptimizedChange == true)
        {
            japonica.transform.position = firstPosition;
            japonica.transform.rotation = Quaternion.Euler(firstRotation);

            openJaponica = false;
            clickAction.SetActive(true);
            allInputfield.SetActive(false);

            d = 0;

        }

    }
}

