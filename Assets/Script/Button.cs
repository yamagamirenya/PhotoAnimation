using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;



public class Button : MonoBehaviour {

    // Use this for initialization

    string str;

    public InputField 
        inputfield;

    public TextMesh
        text, 
        chokeText;

    public GameObject
        mainCamera,
        allInputfield, 
        clickAction, 
        fallPhoto, 
        dowarfPhotos;

    public void SaveText()
    {
        str = inputfield.text;

        text.text = str;
        chokeText.text = str;
        inputfield.text = "";

        mainCamera.GetComponent<BlurOptimized>().enabled = false;

        //Destroy(AllInputfield);
        //Destroy(ClickAction);

        allInputfield.SetActive(false);
        clickAction.SetActive(false);

        print("osareteru");
        fallPhoto.SetActive(true);
        dowarfPhotos.SetActive(true);
    }


    
}
