using UnityEngine;
using System.Collections;



[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class Origami : MonoBehaviour
{
    public GameObject origami2;
    float t;
    public Material _mat;
   

    void Update()
    {
        t += Time.deltaTime;
        

        if(Mathf.Lerp(0, Mathf.PI, t * 0.2f)==Mathf.PI)
        {
            origami2.SetActive(true);
            origami2.GetComponent<Origami2>().enabled = true;
            Destroy(this.gameObject);
        }

        Origami1Mesh();


    }

    void Origami1Mesh()
    {

        var mesh = new Mesh();
        mesh.vertices = new Vector3[]
        {

        new Vector3(0f,1f),
        new Vector3(1f,-0f),
        new Vector3(-1f,-0f),

        new Vector3(1f,0f),
        new Vector3(1f,-1f),
        new Vector3(-1f,-1f),

        new Vector3(-1f,-0f),
        new Vector3(-1f,-1f),
        new Vector3(1f,-0f),
        

        //changing

            new Vector3(0f,1f),
            new Vector3(-1f,0f),
            //new Vector3(-1f+Time.time,1f+Time.time),

            new Vector3(Mathf.Lerp(-1f,0,Time.time*0.1f),Mathf.Lerp(1f,0,t*0.1f),0.5f*Mathf.Sin(Mathf.Lerp(0,Mathf.PI,t*0.2f))),
            new Vector3(0f,1f),
            //new Vector3(1f,1f),
            new Vector3(Mathf.Lerp(1f,0,Time.time*0.1f),Mathf.Lerp(1f,0,t*0.1f),0.5f*Mathf.Sin(Mathf.Lerp(0,Mathf.PI,t*0.2f))),

            new Vector3(1f,0f)

        };

        mesh.triangles = new int[]
        {
            0,1,2,

            3,4,5,

            8,7,6,

            9,10,11,

            12,13,14
        };

        mesh.uv = new Vector2[]
        {
            //triangle
            new Vector2(0.5f,0f),
            new Vector2(1f,0.5f),
            new Vector2(0f,0.5f),
            
            //squar
            new Vector2(1f,0.5f),
            new Vector2(1f,1f),
            new Vector2(0,1f),

            new Vector2(0,0.5f),
            new Vector2(0,1f),
            new Vector2(1f,0.5f),

            new Vector2(0.5f,0f),
            new Vector2(0f,0.5f),
            new Vector2(0f,0f),

            new Vector2(0.5f,0f),
            new Vector2(1f,0f),
            new Vector2(1f,0.5f)



        };

        var filter = GetComponent<MeshFilter>();
        filter.sharedMesh = mesh;

        var renderer = GetComponent<MeshRenderer>();
        renderer.material = _mat;
    }


}