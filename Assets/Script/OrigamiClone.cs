using UnityEngine;
using System.Collections;

public class OrigamiClone : MonoBehaviour {


    public GameObject
      kokuban,
      downArrow,
      choke,
      chokeText,
      appearObject,
      ObjectSender,
      mainCamera,
      TaptoFirstScean,
      kokubanchokeManeger,
        target1, 
        target2, 
        target3, 
        target4,
    origamiSenderToKokuban,
        appearPoint1,
        appearPoint2,
        appearPoint3,
        appearPoint4;

    GameObject 
        target,
        appearPoint;

    bool flyToKokuban,
        flytoObjectSender,
        finalbutton,
        blurOptimizedChange,
        scaleAndAlphaChanging,
        meshChange = true;

    public bool
        kokubanChokeManeger;

    float t = 0,
          n = 0.5f,
          finalPositionY;

    Vector3 toObjectSender,
            toKokubanSender,
            targetPosition,
          firstPosition;

    public Material _mat;





    Vector3 AToBObjectSender(GameObject A, GameObject B,float n)
    {
        Vector3 Answer = new Vector3(Mathf.Lerp(A.transform.position.x, B.transform.position.x, n),
                                     Mathf.Lerp(A.transform.position.y, B.transform.position.y, n),
                                     Mathf.Lerp(A.transform.position.z, B.transform.position.z, n));

        return Answer;
    }

    Vector3 ArcLengthAtoB(GameObject A, GameObject B)
    {
        float answerX = 1 / (1 - (A.transform.position.x - B.transform.position.x));
        float answerY = 1 / (1 - (A.transform.position.y - B.transform.position.y));
        float answerZ = 1 / (1 - (A.transform.position.z - B.transform.position.z));

        return new Vector3(answerX, answerY, answerZ);
    }




    // Use this for initialization
    void Start () {

        _mat.SetFloat("_Alpha", 1);


        if (Random.value < 0.25f)
        {
            target = target1;
        }
        else if (Random.value > 0.25f&&Random.value<0.5f)
        {
            target = target2;

        }
        else if (Random.value > 0.5f && Random.value < 0.75f)
        {
            target = target3;
        }
        else if (Random.value > 0.75f && Random.value < 1f)
        {
            target = target4;
        }else
        {
            target = target4;
        }


        if (Random.value < 0.25f)
        {
            appearPoint = appearPoint1;
            transform.Rotate(0, 90, 270);

        }
        else if (Random.value > 0.25f && Random.value < 0.5f)
        {
            appearPoint = appearPoint2;
            transform.Rotate(0, 90, 270);

        }
        else if (Random.value > 0.5f && Random.value < 0.75f)
        {
            appearPoint = appearPoint3;
            transform.Rotate(0,270,270);
        }
        else if (Random.value > 0.75f && Random.value < 1f)
        {
            appearPoint = appearPoint4;

            transform.Rotate(0, 270, 270);
        }
        else
        {
            appearPoint = appearPoint4;
            transform.Rotate(0, 270, 270);

        }
        firstPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update () {

        t += Time.deltaTime;
                
        if (Mathf.Approximately(Mathf.Lerp(0, Mathf.PI * 0.5f, t * 0.2f), Mathf.PI * 0.5f))
        {
            scaleAndAlphaChanging = true;
            flyToKokuban = true;
            meshChange = false;
        }else
        {
            Origami3Mesh();

        }
        FlyTokokuban();
        ScaleAndAlphaChanging();


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {

            WhenCollideWithKokubanAction();
        }
  

    }


    void Origami3Mesh()
    {
        if (meshChange)
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

    void FlyTokokuban()
    {
        if (flyToKokuban)
        {
            toKokubanSender = AToBObjectSender(appearPoint, target,t*0.05f);
            this.transform.position = toKokubanSender;
        }

    }

    void ScaleAndAlphaChanging()
    {
      
            if (scaleAndAlphaChanging)
            {
            /*
                transform.localScale = new Vector3(Mathf.Lerp(5, 1, ArcLengthAtoB(kokuban, this.gameObject).x),
                                       Mathf.Lerp(5, 1, ArcLengthAtoB(kokuban, this.gameObject).x),
                                       Mathf.Lerp(5, 1, ArcLengthAtoB(kokuban, this.gameObject).x));

            */
                _mat.SetFloat("_Alpha", 1 - ArcLengthAtoB(kokuban, this.gameObject).x);

            }
    }

    void WhenCollideWithKokubanAction()
    {
        print("aaaa");
        Destroy(this.gameObject);
        Instantiate(choke, target.transform.position, Quaternion.Euler(90,90,0));
        /*
        choke.SetActive(true);
        chokeText.SetActive(true);
        kokubanchokeManeger.SetActive(true);
        kokubanchokeManeger.GetComponent<KokubanChokeManeger>().enabled = true;
        kokubanchokeManeger.transform.position = this.transform.position;
*/        
    }

   
}
