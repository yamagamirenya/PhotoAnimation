using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class Origami3 : MonoBehaviour
{
    

    public GameObject 
        kokuban,
        downArrow,
        choke,
        chokeText,
        appearObject,
        ObjectSender, 
        mainCamera,
        TaptoFirstScean;

    bool flyToKokuban,
        flytoObjectSender, 
        finalbutton;

    float t = 0,
          n = 0.5f,
          finalPositionY;

    Vector3 toObjectSender,
            toKokubanSender;

    public Material _mat;




    Vector3 AToBObjectSender(GameObject A, GameObject B)
    {
        Vector3 Answer = new Vector3(Mathf.Lerp(A.transform.position.x, B.transform.position.x, t * 0.05f),
                                     Mathf.Lerp(A.transform.position.y, B.transform.position.y, t * 0.05f),
                                     Mathf.Lerp(A.transform.position.z, B.transform.position.z, t * 0.05f));

        return Answer;
    }

    void Start()
    {
        toObjectSender = AToBObjectSender(ObjectSender, this.gameObject);
    }

    void Update()
    {

        t += Time.deltaTime;

        FlyTokokuban();

        FlyToObjectSender();



        //below is now making..............
        /*
        if (finalbutton)
        {

            if (Input.GetMouseButton(0))
            {
             SceneManager.LoadScene("Main");
            }


        }
        */

        Origami3Mesh();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == kokuban)
        {
            WhenCollideWithKokubanAction();
        }

        if (other.gameObject == ObjectSender)
        {
            WhenCollideWithObjectSender();
        }

    }

    void FlyTokokuban()
    {

        if (flyToKokuban)
        {
            toKokubanSender = AToBObjectSender(appearObject, kokuban);
            this.transform.position = toKokubanSender;
        }
    }

    void FlyToObjectSender()
    {
        if (Input.GetMouseButtonUp(0))
        {
            flytoObjectSender = true;
        }

        if (flytoObjectSender)
        {
            this.transform.position += toObjectSender * Time.deltaTime * 0.1f;
            Destroy(downArrow);
        }

    }

    void WhenCollideWithKokubanAction()
    {
            Destroy(this.gameObject);
            choke.SetActive(true);
            chokeText.SetActive(true);   

    }

    void WhenCollideWithObjectSender()
    {
        transform.position = appearObject.transform.position;

        flyToKokuban = true;
        flytoObjectSender = false;
        //  finalbutton = true;
        mainCamera.GetComponent<BlurOptimized>().enabled = true;
        TaptoFirstScean.SetActive(true);

        transform.localScale = new Vector3(1, 1, 1);

    }

    void Origami3Mesh()
    {
        var mesh = new Mesh();
        mesh.vertices = new Vector3[]
        {
            //leftside
            //new Vector3(0,0.5f),
            new Vector3(Mathf.Lerp(0,0.25f,t*0.1f),0.5f,Mathf.Sin(Mathf.Lerp(0,Mathf.PI*0.5f,t*0.2f))*0.5f),

            new Vector3(0.25f,0.25f),
            new Vector3(0.25f,0.5f),

            // new Vector3(0,0.5f),
                        new Vector3(Mathf.Lerp(0,0.25f,t*0.1f),0.5f,Mathf.Sin(Mathf.Lerp(0,Mathf.PI*0.5f,t*0.2f))*0.5f),

            //new Vector3(0,1),
                        new Vector3(Mathf.Lerp(0,0.25f,t*0.1f),1f,Mathf.Sin(Mathf.Lerp(0,Mathf.PI*0.5f,t*0.2f))*0.5f),

            new Vector3(0.25f,1),

            new Vector3(0.25f,1),
            new Vector3(0.25f,0.5f),
           // new Vector3(0,0.5f),
                       new Vector3(Mathf.Lerp(0,0.25f,t*0.1f),0.5f,Mathf.Sin(Mathf.Lerp(0,Mathf.PI*0.5f,t*0.2f))*0.5f),


            new Vector3(0.5f,0),
            new Vector3(0.5f,0.25f),
            new Vector3(0.25f,0.25f),

            new Vector3(0.5f,0.25f),
            new Vector3(0.5f,0.5f),
            new Vector3(0.25f,0.25f),

            new Vector3(0.25f,0.25f),
            new Vector3(0.25f,0.5f),
            new Vector3(0.5f,0.5f),


            new Vector3(0.25f,0.5f),
            new Vector3(0.5f,1),
            new Vector3(0.5f,0.5f),

            new Vector3(0.25f,0.5f),
            new Vector3(0.25f,1),
            new Vector3(0.5f,1),

            //rightside

            // new Vector3(0,0.5f),
                        new Vector3(Mathf.Lerp(0,0.25f,t*0.1f),0.5f,-Mathf.Sin(Mathf.Lerp(0,Mathf.PI*0.5f,t*0.2f))*0.5f),

            new Vector3(0.25f,0.25f),
            new Vector3(0.25f,0.5f),

         //   new Vector3(0,0.5f),
                                    new Vector3(Mathf.Lerp(0,0.25f,t*0.1f),0.5f,-Mathf.Sin(Mathf.Lerp(0,Mathf.PI*0.5f,t*0.2f))*0.5f),

           // new Vector3(0,1),
                                   new Vector3(Mathf.Lerp(0,0.25f,t*0.1f),1f,-Mathf.Sin(Mathf.Lerp(0,Mathf.PI*0.5f,t*0.2f))*0.5f),

            new Vector3(0.25f,1),

            new Vector3(0.25f,1),
            new Vector3(0.25f,0.5f),
         //   new Vector3(0,0.5f),
                                    new Vector3(Mathf.Lerp(0,0.25f,t*0.1f),0.5f,-Mathf.Sin(Mathf.Lerp(0,Mathf.PI*0.5f,t*0.2f))*0.5f),



            new Vector3(0.5f,0),
            new Vector3(0.5f,0.25f),
            new Vector3(0.25f,0.25f),

            new Vector3(0.5f,0.5f),
            new Vector3(0.5f,0.5f),
            new Vector3(0.25f,0.25f),

            new Vector3(0.25f,0.25f),
            new Vector3(0.25f,0.5f),
            new Vector3(0.5f,0.5f),


            new Vector3(0.25f,0.5f),
            new Vector3(0.5f,1),
            new Vector3(0.5f,0.5f),

            new Vector3(0.25f,0.5f),
            new Vector3(0.25f,1),
            new Vector3(0.5f,1),


        };

        mesh.triangles = new int[]
        {
            0,1,2,

            3,4,5,

            8,7,6,

            9,10,11,

            12,13,14,

            15,16,17,

            18,19,20,

            21,22,23,

            24,25,26,

            27,28,29,

            30,31,32,

            33,34,35,

            36,37,38,

            39,40,41,

            42,43,44,

            45,46,47
        };

        mesh.uv = new Vector2[]
        {
     //leftside
          new Vector2(0,0.5f),

            new Vector2(0.25f,0.25f),
            new Vector2(0.25f,0.5f),

             new Vector2(0,0.5f),

            new Vector2(0,1),

            new Vector2(0.25f,1),

            new Vector2(0.25f,1),
            new Vector2(0.25f,0.5f),
           new Vector2(0,0.5f),


            new Vector2(0.5f,0),
            new Vector2(0.5f,0.25f),
            new Vector2(0.25f,0.25f),

            new Vector2(0.5f,0.25f),
            new Vector2(0.5f,0.5f),
            new Vector2(0.25f,0.25f),

            new Vector2(0.25f,0.25f),
            new Vector2(0.25f,0.5f),
            new Vector2(0.5f,0.5f),


            new Vector2(0.25f,0.5f),
            new Vector2(0.5f,1),
            new Vector2(0.5f,0.5f),

            new Vector2(0.25f,0.5f),
            new Vector2(0.25f,1),
            new Vector2(0.5f,1),

            //rightside

            new Vector2(0+n,0.5f),

            new Vector2(0.25f+n,0.25f),
            new Vector2(0.25f+n,0.5f),

             new Vector2(0+n,0.5f),

            new Vector2(0+n,1),

            new Vector2(0.25f+n,1),

            new Vector2(0.25f+n,1),
            new Vector2(0.25f+n,0.5f),
           new Vector2(0+n,0.5f),


            new Vector2(0.5f+n,0),
            new Vector2(0.5f+n,0.25f),
            new Vector2(0.25f+n,0.25f),

            new Vector2(0.5f+n,0.25f),
            new Vector2(0.5f+n,0.5f),
            new Vector2(0.25f+n,0.25f),

            new Vector2(0.25f+n,0.25f),
            new Vector2(0.25f+n,0.5f),
            new Vector2(0.5f+n,0.5f),


            new Vector2(0.25f+n,0.5f),
            new Vector2(0.5f+n,1),
            new Vector2(0.5f+n,0.5f),

            new Vector2(0.25f+n,0.5f),
            new Vector2(0.25f+n,1),
            new Vector2(0.5f+n,1),



        };

        var filter = GetComponent<MeshFilter>();
        filter.sharedMesh = mesh;

        var renderer = GetComponent<MeshRenderer>();
        renderer.material = _mat;


    }






}
