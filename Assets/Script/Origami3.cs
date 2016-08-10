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
        appearPoint1,
        appearPoint2,
        appearPoint3,
        appearPoint4,
        target1,
        target2,
        target3,
        target4,
        ObjectSender,
        mainCamera,
        TaptoFirstScean,
        kokubanchokeManeger;
    GameObject
        target,
        appearPoint;

    bool flyToKokuban,
        flytoObjectSender,

        scaleAndAlphaChanging,
        //  appearPointChange = true,
        alphaChangingByTime,
        targetTextureFlipChang;
    //firstPositionSet;

    public bool
        kokubanChokeManeger,
        finalbutton,
        blurOptimizedChange,
        origamiFinal;

   public  float 
          t = 0,
          n = 0.5f,
          r = 0,
          finalPositionY;

    public RenderTexture renderTexture;

    Vector3 toObjectSender,
            toKokubanSender,
            firstPosition;
            

    public Material _mat;

    Material material;


    BlurOptimized blurOptimizerd;

    Vector3 firstRotation,
            firstScale;

    Vector3 AToBObjectSender(GameObject A, GameObject B, float n)
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

    public Color32[]
        color32;


    void Start()
    {
        renderTexture.Release();
        firstPosition = this.transform.position;
        firstScale = transform.localScale;
        firstRotation = transform.localEulerAngles;
       

        toObjectSender = AToBObjectSender(ObjectSender, this.gameObject,t*0.05f);
        blurOptimizerd = mainCamera.GetComponent<BlurOptimized>();
        _mat.SetFloat("_Alpha", 1);

        TargetPointChange();


    }

    void Update()
    {

        t += Time.deltaTime;

        FlyTokokuban();

        FlyToObjectSender();

        

        
        if (finalbutton)
        {


            if (Input.GetMouseButton(0))
            {
                OriginalOrigami3Mesh();

                blurOptimizedChange = false;
                FinishAndStart();

            }

        }

            Origami3Mesh();

            BlurOptimizedChange();

            AlphaChangingByTime();

            TargetTextureFlipChang();

    }

    void TargetPointChange()
    {
        if (Random.value < 0.25f)
        {
            target = target1;
        }
        else if (Random.value > 0.25f && Random.value < 0.5f)
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
        }
        else
        {
            target = target4;
        }
    }

    void AppearPointChange()
    {
        if (Random.value < 0.25f)
        {
            appearPoint = appearPoint1;
            transform.rotation = Quaternion.Euler(0, 90, 270);

        }
        else if (Random.value > 0.25f && Random.value < 0.5f)
        {
            appearPoint = appearPoint2;
            transform.rotation = Quaternion.Euler(0, 90, 270);

        }
        else if (Random.value > 0.5f && Random.value < 0.75f)
        {
            appearPoint = appearPoint3;
            transform.rotation = Quaternion.Euler(0, 270, 270);
        }
        else if (Random.value > 0.75f && Random.value < 1f)
        {
            appearPoint = appearPoint4;

            transform.rotation = Quaternion.Euler(0, 270, 270);
        }
        else
        {
            appearPoint = appearPoint4;
            transform.rotation = Quaternion.Euler(0, 270, 270);

        }

        material = target.GetComponent<Renderer>().material;

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

    void BlurOptimizedChange()
    {
        if (blurOptimizedChange)
        {
            if (blurOptimizerd.blurSize < 10)
                blurOptimizerd.blurSize += 2 * Time.deltaTime;

            if (blurOptimizerd.blurSize >= 5)
            {
                TaptoFirstScean.SetActive(true);
            }
        }
       

    }

    void ScaleAndAlphaChanging()
    {
        if (scaleAndAlphaChanging)
        {
            /*
            transform.localScale = new Vector3(Mathf.Lerp(5, 1, ArcLengthAtoB(kokuban, this.gameObject).x),
                                       Mathf.Lerp(5, 1, ArcLengthAtoB(kokuban, this.gameObject).y),
                                       Mathf.Lerp(5, 1, ArcLengthAtoB(kokuban, this.gameObject).z));

           */
            _mat.SetFloat("_Alpha", 1 - ArcLengthAtoB(kokuban, this.gameObject).x);
        }

    }

    void FlyTokokuban()
    {

        if (flyToKokuban)
        {
         
            toKokubanSender = AToBObjectSender(appearPoint,target,t*0.05f);
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
            downArrow.SetActive(false);
            downArrow.GetComponent<UpArrow>().enabled = false;
        }

    }

    void AlphaChangingByTime()
    {
        if (alphaChangingByTime)
        {
            r += Time.deltaTime;
            
            _mat.SetFloat("_Alpha", 1 - r * 0.5f);

            targetTextureFlipChang = true;

            if (Mathf.Approximately(1 - r * 0.5f, 0))
            {
                //Destroy(this.gameObject);
            }
        }

    }

    void TargetTextureFlipChang()
    {
        if (targetTextureFlipChang)
        {
            material.SetFloat("_Flip", r*0.5f-0.5f);
        }

    }

    void WhenCollideWithKokubanAction()
    {
        /*
        var ptr = renderTexture.GetNativeTexturePtr();
        Texture2D texture = Texture2D.CreateExternalTexture(renderTexture.width, renderTexture.height,TextureFormat.ARGB32,false,false,ptr);
        this.gameObject.GetComponent<Renderer>().material.mainTexture = texture;
        //texture.SetPixels32(color32);
        texture.Apply();

    */
        print("butukattaqyo");
        this.gameObject.GetComponent<Rigidbody>().isKinematic=true;
        alphaChangingByTime = true;
        flyToKokuban = false;
        


        target.GetComponent<Renderer>().material.mainTexture = this.gameObject.GetComponent<Renderer>().material.mainTexture;
        origamiFinal = true;

    }

    void WhenCollideWithObjectSender()
    {
        transform.rotation =Quaternion.Euler(0, 0, 0);
        AppearPointChange();

        transform.position = appearPoint.transform.position;


        flyToKokuban = true;
        flytoObjectSender = false;
        blurOptimizedChange = true;
        scaleAndAlphaChanging = true;
         finalbutton = true;
        mainCamera.GetComponent<BlurOptimized>().enabled = true;
        

        transform.localScale = new Vector3(1,1,1);
        
    }

    void Origami3Mesh()
    {
        var mesh = new Mesh();
        mesh.vertices = new Vector3[]
        {
            //leftside
            //new Vector3(0, 0.5f),
            
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

    void OriginalOrigami3Mesh()
    {
        print("original");

        var mesh = new Mesh();
        mesh.vertices = new Vector3[]
        {
            //leftside
            new Vector3(0, 0.5f),
            new Vector3(0.25f,0.25f),
            new Vector3(0.25f,0.5f),

             new Vector3(0,0.5f),
            new Vector3(0,1),
            new Vector3(0.25f,1),

            new Vector3(0.25f,1),
            new Vector3(0.25f,0.5f),
            new Vector3(0,0.5f),


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

             new Vector3(0,0.5f),
            new Vector3(0.25f,0.25f),
            new Vector3(0.25f,0.5f),

            new Vector3(0,0.5f),
            new Vector3(0,1),
            new Vector3(0.25f,1),

            new Vector3(0.25f,1),
            new Vector3(0.25f,0.5f),
            new Vector3(0,0.5f),



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
    
    void FinishAndStart()
    {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        origamiFinal = false;
        t = 0;
        print("owattayop");
        this.transform.position = firstPosition;
        this.transform.Rotate(Vector3.zero);
        this.transform.localScale = firstScale;
        transform.rotation =  Quaternion.Euler(firstRotation);
        _mat.SetFloat("_Alpha",1);
        blurOptimizerd.blurSize = 0;
       
        alphaChangingByTime = false;
        flyToKokuban = false;
        flytoObjectSender = false;
        finalbutton = false;
        blurOptimizedChange = false;
        scaleAndAlphaChanging = false;
       // appearPointChange = true;
        alphaChangingByTime = false;
        targetTextureFlipChang=false;
      //  firstPositionSet = false;

        this.gameObject.SetActive(false);
        this.gameObject.GetComponent<Origami3>().enabled = false;
    }

}
