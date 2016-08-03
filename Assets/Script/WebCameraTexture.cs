using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WebCameraTexture : MonoBehaviour {


    public int
        width = 1920, 
        height = 1080, 
        FPS = 30;
   
    public GameObject 
        paperphoto, 
        rendererTexture, 
        chokeTexture;

    public RawImage
        rawimage;

    public Color32[] 
        color32;

    WebCamTexture 
        webcamTexture;
    

	// Use this for initialization
	void Start () {
        WebCameraTextureSetting();
	}
	
	// Update is called once per frame
	
    void Update()
    {
        WebCameraToAnotherTexture();
    }

    void WebCameraTextureSetting()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        webcamTexture = new WebCamTexture(devices[0].name, width, height, FPS);
        rawimage.texture = webcamTexture;
        rawimage.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }

    void WebCameraToAnotherTexture()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
        {
            color32 = webcamTexture.GetPixels32();
            Texture2D texture = new Texture2D(webcamTexture.width, webcamTexture.height);

            paperphoto.GetComponent<Renderer>().material.mainTexture = texture;
            chokeTexture.GetComponent<Renderer>().material.mainTexture = texture;
            rendererTexture.GetComponent<Renderer>().material.mainTexture = texture;

            texture.SetPixels32(color32);
            texture.Apply();
        }
    }
	
}
