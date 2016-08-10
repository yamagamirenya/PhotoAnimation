using UnityEngine;
using System.Collections;

public class UpArrow : MonoBehaviour
{
    public GameObject upActionObject;


    Vector3 firstPosition;
    // Use this for initialization
    void Start()
    {

        firstPosition = upActionObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        UpArrowAction();

    }

    void UpArrowAction()
    {
        if (upActionObject.transform.position.y < 4.5f)
        {
            upActionObject.transform.position = Vector3.Lerp(upActionObject.transform.position, new Vector3(-1.18f, 4.72f, 3.101f), Time.deltaTime * 0.8f);
        }
        else if (upActionObject.transform.position.y >= 4.5f)
        {
            upActionObject.transform.position = firstPosition;
        }

    }
}