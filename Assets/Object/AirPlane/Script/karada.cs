using UnityEngine;
using System.Collections;


[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]

public class karada : MonoBehaviour {



	// Use this for initialization
	void Start () {

        var Mesh = new Mesh();
        Mesh.vertices = new Vector3[]
        {
            //usiro
            new Vector3(0.5f,0.5f,-0.5f),//0
            new Vector3(0.5f,-0.5f,-0.5f),//1
            new Vector3(-0.5f,-0.5f,-0.5f),//2
            new Vector3(-0.5f,0.5f,-0.5f),//3

            //ue
            new Vector3(0.5f,0.5f,0.25f),//4
        new Vector3(-0.5f, 0.5f, 0.25f),//5
        new Vector3(-0.5f,0.5f,-0.5f),//6
        new Vector3(0.5f,0.5f,-0.5f),//7


        //top
        new Vector3(0.5f,0.5f,0.25f),//8
        new Vector3(-0.5f,0.5f,0.25f),//9
        new Vector3(-0.5f,-0.25f,0.5f),//10
        new Vector3(0.5f,-0.25f,0.5f),//11

        //migiyoko
        new Vector3(-0.5f,0.5f,-0.5f),//12
        new Vector3(-0.5f,0.5f,0.25f),//13
        new Vector3(-0.5f,-0.25f,0.5f),//14
        new Vector3(-0.5f,-0.25f,-0.5f),//15


        //hidariyoko
        new Vector3(0.5f,0.5f,-0.5f),//16
        new Vector3(0.5f,0.5f,0.25f),//17
        new Vector3(0.5f,-0.25f,0.5f),//18
        new Vector3(0.5f,-0.25f,-0.5f),//19

        new Vector3(0.5f,-0.25f,-0.5f),//20
        new Vector3(0.5f,-0.5f,-0.5f),//21
        new Vector3(0.5f,-0.5f,0.5f),//22
        new Vector3(0.5f,-0.25f,0.5f),//23

        new Vector3(-0.5f,-0.25f,-0.5f),//24
        new Vector3(-0.5f,-0.5f,-0.5f),//25
        new Vector3(-0.5f,-0.5f,0.5f),//26
        new Vector3(-0.5f,-0.25f,0.5f),//27

        new Vector3(0.5f,-0.25f,0.5f),//28
        new Vector3(0.5f,-0.5f,0.5f),//29
        new Vector3(-0.5f,-0.5f,0.5f),//30
        new Vector3(-0.5f,-0.25f,0.5f),//31

        new Vector3(0.5f,-0.5f,0.5f),//32
        new Vector3(-0.5f,-0.5f,0.5f),//33
        new Vector3(-0.5f,-0.5f,-0.5f),//34
        new Vector3(0.5f,-0.5f,-0.5f),//35


        };

        Mesh.triangles = new int[]
        {
            0,1,2,
            2,3,0,

            7,6,5,
            5,4,7,

           8,9,10,
           10,11,8,

           15,14,13,
           13,12,15,

           16,17,18,
           18,19,16,

           23,22,21,
           21,20,23,

           24,25,26,
           26,27,24,

           31,30,29,
           29,28,31,

            32,33,34,
            34,35,32,
        };

        var filter = GetComponent<MeshFilter>();
        Mesh.RecalculateNormals();
        Mesh.RecalculateBounds();
        filter.sharedMesh = Mesh;

        Mesh.Optimize();


    }


}
