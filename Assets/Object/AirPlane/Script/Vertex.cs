using UnityEngine;
using System.Collections;

public class Vertex : MonoBehaviour {


    public Vector3 vertLeftTopDFront = new Vector3(-1, 1, 1);


	// Use this for initialization
	void Start () {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = mf.mesh;

        Vector3[] vertices = new Vector3[]
        {
            new Vector3 (-1,1,1),
        new Vector3(1, 1, 1),
        new Vector3(-1, -1, 1),
        new Vector3(1,-1,1),


        new Vector3(1,1,-1),
        new Vector3(-1,1,-1),
        new Vector3(1,-1,-1),
        new Vector3(-1, -1, -1),

         new Vector3(-1,1,-1),
        new Vector3(-1,1,1),
        new Vector3(-1,-1,-1),
        new Vector3(-1, -1, 1),

         new Vector3(1,1,1),
        new Vector3(1,1,-1),
        new Vector3(1,-1,1),
        new Vector3(1, 1, -1),

        new Vector3(-1,-1,1),
        new Vector3(1,-1,1),
        new Vector3(-1,-1,-1),
        new Vector3(1, 1, -1),

        };





        int[] triangles = new int[]
        {
            0,2,3,
            3,1,0,

            4,6,7,
            7,5,4,

            8,10,11,
            11,9,8,

            12,14,15,
            15,13,12,

            16,18,19,
            19,17,16,

            20,22,23,
            23,21,20







        };

        Vector2[] uvs = new Vector2[]
        {
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

              new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

              new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

              new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),
        };


        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.Optimize();
        mesh.RecalculateNormals();



    }

    // Update is called once per frame
    void Update () {
	
	}
}
