using UnityEngine;
using System.Collections;


[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class triangle : MonoBehaviour {


   

	// Use this for initialization
	void Start () {
        var Mesh = new Mesh();
        Mesh.vertices = new Vector3[]
        {
           new Vector3 (-0.5f,0.5f,0),//0
           new Vector3(0.5f,0.5f,0),//1
           new Vector3(0,0,-1f),//2

            new Vector3 (-0.5f,0.5f,0),//3
            new Vector3(-0.5f,-0.5f,0),//4
            new Vector3(0,0,-1f),//5

            new Vector3(-0.5f,-0.5f,0f),//6
            new Vector3(0.5f,-0.5f,0f),//7
            new Vector3(0,0,-1f),//8

            new Vector3(0.5f,-0.5f,0f),//9
            new Vector3(0.5f,0.5f,0f),//10
            new Vector3(0,0,-1f),//11

            new Vector3(-0.5f,0.5f,0),//12
            new Vector3(0.5f,0.5f,0),//13
            new Vector3(0.5f,-0.5f,0),//14
            new Vector3(-0.5f,-0.5f,0)//15





        };

        Mesh.triangles = new int[]
        {
            0,1,2,

            5,4,3,

           8,7,6,

           11,10,9,

            15,14,13,
            15,13,12,

         
        };

        var filter = GetComponent<MeshFilter>();
        Mesh.RecalculateNormals();
        Mesh.RecalculateBounds();
        filter.sharedMesh = Mesh;
        
        Mesh.Optimize();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
