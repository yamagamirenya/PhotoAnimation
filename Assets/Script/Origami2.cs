using UnityEngine;
using System.Collections;



[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class Origami2 : MonoBehaviour
{
    public GameObject 
        origami3, 
        downUI;

    public float t=0;

    public Material _mat;

    Origami3 origami3Script;

    //Start is nothing
    void Start()
    {

        origami3Script = origami3.GetComponent<Origami3>();

    }

    void Update()
    {
        t += Time.deltaTime;

        if (Mathf.Lerp(0, Mathf.PI, t * 0.2f) == Mathf.PI)
        {
            origami3.SetActive(true);
            origami3Script.enabled = true;
            downUI.SetActive(true);
            this.gameObject.GetComponent<MeshRenderer>().enabled = false; ;           
        }

        if (origami3Script.blurOptimizedChange == true)
        {
            OriginalOrigami2Mesh();
        }
        else
        {
            Origami2Mesh();

        }


    }



    void Origami2Mesh()
    {
        var mesh = new Mesh();
        mesh.vertices = new Vector3[]
        {

        new Vector3(0.5f,0),
        new Vector3(0.5f,0.5f),
        //new Vector3(0,0.5f),
        new Vector3(Mathf.Lerp(0,0.5f,t*0.2f),0.5f,Mathf.Sin(Mathf.Lerp(0,Mathf.PI*0.5f,t*0.2f))*0.5f),


        new Vector3(0.5f,0),
        //new Vector3(1,0.5f),
        new Vector3(Mathf.Lerp(1f,0.5f,t*0.2f),0.5f,Mathf.Sin(Mathf.Lerp(0,Mathf.PI*0.5f,t*0.2f))*0.5f),
        new Vector3(0.5f,0.5f),

        new Vector3(0.5f,0.5f),
        //new Vector3(1,0.5f),
                new Vector3(Mathf.Lerp(1f,0.5f,t*0.2f),0.5f,Mathf.Sin(Mathf.Lerp(0,Mathf.PI*0.5f,t*0.2f))*0.5f),

        //new Vector3(1,1),
        new Vector3(Mathf.Lerp(1f,0.5f,t*0.2f),1f,Mathf.Sin(Mathf.Lerp(0,Mathf.PI*0.5f,t*0.2f))*0.5f),


        //new Vector3(1,1),
                new Vector3(Mathf.Lerp(1f,0.5f,t*0.2f),1f,Mathf.Sin(Mathf.Lerp(0,Mathf.PI*0.5f,t*0.2f))*0.5f),

        new Vector3(0.5f,1),
        new Vector3(0.5f,0.5f),


        new Vector3(0.5f,0.5f),
            // new Vector3(0,0.5f),
                    new Vector3(Mathf.Lerp(0,0.5f,t*0.2f),0.5f,Mathf.Sin(Mathf.Lerp(0,Mathf.PI*0.5f,t*0.2f))*0.5f),

            new Vector3(0.5f,1),

//        new Vector3(0,0.5f),
         new Vector3(Mathf.Lerp(0,0.5f,t*0.2f),0.5f,Mathf.Sin(Mathf.Lerp(0,Mathf.PI*0.5f,t*0.2f))*0.5f),
    //  new Vector3(0,1),
        new Vector3(Mathf.Lerp(0,0.5f,t*0.2f),1f,Mathf.Sin(Mathf.Lerp(0,Mathf.PI*0.5f,t*0.2f))*0.5f),
        new Vector3(0.5f,1)




        };

        mesh.triangles = new int[]
        {
            0,1,2,

            3,4,5,

            8,7,6,

            9,10,11,

            12,13,14,

            15,16,17
        };

        mesh.uv = new Vector2[]
        {
        new Vector2(0.5f,0),
        new Vector2(0.5f,0.5f),
        new Vector2(0,0.5f),

        new Vector2(0.5f,0),
        new Vector2(1,0.5f),
        new Vector2(0.5f,0.5f),

        new Vector2(0.5f,0.5f),
        new Vector2(1,0.5f),
        new Vector2(1,1),

        new Vector2(1,1),
        new Vector2(0.5f,1),
        new Vector2(0.5f,0.5f),


        new Vector2(0.5f,0.5f),
        new Vector2(0,0.5f),
        new Vector2(0.5f,1),

        new Vector2(0,0.5f),
        new Vector2(0,1),
        new Vector2(0.5f,1)



        };

        var filter = GetComponent<MeshFilter>();
        filter.sharedMesh = mesh;

        var renderer = GetComponent<MeshRenderer>();
        renderer.material = _mat;

    }

    void OriginalOrigami2Mesh()
    {

        var mesh = new Mesh();
        mesh.vertices = new Vector3[]
        {

        new Vector3(0.5f,0),
        new Vector3(0.5f,0.5f),
        new Vector3(0,0.5f),


        new Vector3(0.5f,0),
        new Vector3(1,0.5f),
        new Vector3(0.5f,0.5f),

        new Vector3(0.5f,0.5f),
        new Vector3(1,0.5f),

        new Vector3(1,1),


        new Vector3(1,1),
        new Vector3(0.5f,1),
        new Vector3(0.5f,0.5f),


        new Vector3(0.5f,0.5f),
        new Vector3(0,0.5f),
        new Vector3(0.5f,1),

        new Vector3(0,0.5f),
        new Vector3(0,1),
        new Vector3(0.5f,1)




        };

        mesh.triangles = new int[]
        {
            0,1,2,

            3,4,5,

            8,7,6,

            9,10,11,

            12,13,14,

            15,16,17
        };

        mesh.uv = new Vector2[]
        {
        new Vector2(0.5f,0),
        new Vector2(0.5f,0.5f),
        new Vector2(0,0.5f),

        new Vector2(0.5f,0),
        new Vector2(1,0.5f),
        new Vector2(0.5f,0.5f),

        new Vector2(0.5f,0.5f),
        new Vector2(1,0.5f),
        new Vector2(1,1),

        new Vector2(1,1),
        new Vector2(0.5f,1),
        new Vector2(0.5f,0.5f),


        new Vector2(0.5f,0.5f),
        new Vector2(0,0.5f),
        new Vector2(0.5f,1),

        new Vector2(0,0.5f),
        new Vector2(0,1),
        new Vector2(0.5f,1)



        };

        var filter = GetComponent<MeshFilter>();
        filter.sharedMesh = mesh;

        var renderer = GetComponent<MeshRenderer>();
        renderer.material = _mat;



    }

}