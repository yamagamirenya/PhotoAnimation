using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class WWWTest : MonoBehaviour {

   
    public GameObject Text;
	// Use this for initialization
	IEnumerator Start () {

        string path1 = "http://localhost:81/uploads/flower_high.jpg";
        string fileName = Path.GetFileNameWithoutExtension(path1);

        Console.WriteLine(fileName);


        //----------------------------------------------------------------------------
        string url = "http://localhost:81/uploads/1";
        WWW texturewww = new WWW(url);
        yield return texturewww;
        GetComponent<Renderer>().material.mainTexture = texturewww.texture;
        //-----------------------------------------------------------------------------
        
        //tring url_text = "http://localhost:81/test.php";
        //WWW www = new WWW(url_text);
       // Console.WriteLine(www.text);     
	
	}


  
	
	// Update is called once per frame
	void Update () {
	
	}
}
