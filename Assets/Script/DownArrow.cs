using UnityEngine;
using System.Collections;

public class DownArrow : MonoBehaviour
{
    public GameObject downActionObject;

  
    Vector3 firstPosition;
    // Use this for initialization
    void Start()
    {

        firstPosition = downActionObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        DownArrowAction();

    }

    void DownArrowAction()
    {
        if (downActionObject.transform.position.y > 1.5f)
        {
            downActionObject.transform.position = Vector3.Lerp(downActionObject.transform.position, new Vector3(-0.41f, 1.14f, 3.06f), Time.deltaTime * 0.8f);
        }
        else if (downActionObject.transform.position.y <= 1.5f)
        {
            downActionObject.transform.position = firstPosition;
        }

    }
}