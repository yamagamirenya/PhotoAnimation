using UnityEngine;
using System.Collections;

public class FinishToStartManager : MonoBehaviour
{
    const string TEXNAME_PAPER = "Resources/Paper";
    const string TEXNAME_PAPER2 = "Resources/Paper2";
    const string TEXNAME_PAPER3 = "Resources/Paper3";
    const string TEXNAME_PAPER4 = "Resources/Paper4";

    Texture2D
        TEX_PAPER,
        TEX_PAPER2,
        TEX_PAPER3,
        TEX_PAPER4;


    public GameObject
        fallPhoto,
        japonicaNote,
        origami1,
        origami2,
        origami3,
        upArrow,
        paperPhoto1,
        paperPhoto2,
        paperPhoto3,
        paperPhoto4,
        tapToFirstScean;
    

   Vector3 japonicaNoteFirstPosition;

    Material 
        notePhotoMaterial1,
        notePhotoMaterial2,
        notePhotoMaterial3,
        notePhotoMaterial4,
        fallPhotoMaterial;

    Origami3 origami3Script;

    // Use this for initialization
    void Start()
    {

        TextureSetting();

        origami3Script = origami3.GetComponent<Origami3>();
        notePhotoMaterial1 = paperPhoto1.GetComponent<Renderer>().material;
        notePhotoMaterial2 = paperPhoto2.GetComponent<Renderer>().material;
        notePhotoMaterial3 = paperPhoto3.GetComponent<Renderer>().material;
        notePhotoMaterial4 = paperPhoto4.GetComponent<Renderer>().material;



        fallPhotoMaterial = fallPhoto.GetComponent<Renderer>().material;
        japonicaNoteFirstPosition = japonicaNote.transform.position;
    }

    void TextureSetting()
    {
        TEX_PAPER = Resources.Load(TEXNAME_PAPER) as Texture2D;
        TEX_PAPER2 = Resources.Load(TEXNAME_PAPER2) as Texture2D;
        TEX_PAPER3 = Resources.Load(TEXNAME_PAPER3) as Texture2D;
        TEX_PAPER4 = Resources.Load(TEXNAME_PAPER4) as Texture2D;
    }

    // Update is called once per frame
    void Update()
    {
        FinishAndStart();
    }

    void FinishAndStart()
    {

        if (origami3Script.finalbutton == true)
        {
            upArrow.SetActive(false);

            FallPhotoReloadToFirst();

            MaterialAlphaFirstSetting();

            JaponicaNoteReloadToFirst();

            RandomPhotoGetter();
           
            fallPhoto.SetActive(false);

            Origami1ReloadToFirst();

            Origami2ReloadToFirst();

            tapToFirstScean.SetActive(false);


        }
    }
    //below is contained in upper;
    void RandomPhotoGetter()
    {
        if (origami3Script.origamiFinal)
        {
            Material japonicaNoteMaterial = japonicaNote.GetComponent<Renderer>().material;

            if (Random.value <= 0.25f)
            {
                print("1");
                fallPhotoMaterial = Resources.Load<Material>("FallPhoto");
                notePhotoMaterial1 = Resources.Load<Material>("FallPhoto");
                japonicaNoteMaterial.mainTexture = TEX_PAPER;
            }
            else if (Random.value > 0.25f && Random.value <= 0.5f)
            {
                print("2");
                fallPhotoMaterial = Resources.Load<Material>("FallPhoto2");
                notePhotoMaterial2 = Resources.Load<Material>("FallPhoto2");
                japonicaNoteMaterial.mainTexture = TEX_PAPER2;

            }
            else if (Random.value > 0.5f && Random.value <= 0.75f)
            {
                print("3");
                fallPhotoMaterial = Resources.Load<Material>("FallPhoto3");
                notePhotoMaterial3 = Resources.Load<Material>("FallPhoto3");
                japonicaNoteMaterial.mainTexture = TEX_PAPER3;

            }
            if (Random.value > 0.75f && Random.value < 1.0f)
            {
                print("4");
                fallPhotoMaterial = Resources.Load<Material>("FallPhoto4");
                notePhotoMaterial4 = Resources.Load<Material>("FallPhoto4");
                japonicaNoteMaterial.mainTexture = TEX_PAPER4;

            }
        }
    }

    void MaterialAlphaFirstSetting()
    {
        fallPhotoMaterial.SetFloat("_Alpha", 1);
       // notePhotoMaterial.SetFloat("_Alpha", 0);
    }

    void FallPhotoReloadToFirst()
    {
        fallPhoto.SetActive(true);
        fallPhoto.GetComponent<BoxCollider>().enabled = true;
        FallPhoto fallPhotoScript = fallPhoto.GetComponent<FallPhoto>();
        fallPhotoScript.enabled = true;
        fallPhotoScript.move = true;
        fallPhotoScript.nextFallPhotoActiom = false;
        fallPhotoScript.japonicaAction = false;
        fallPhotoScript.t = 0;

    }

    void JaponicaNoteReloadToFirst()
    {

        japonicaNote.SetActive(true);
        japonicaNote.transform.position = japonicaNoteFirstPosition;
    }

    void Origami1ReloadToFirst()
    {
        origami1.SetActive(false);
        origami1.GetComponent<Origami>().enabled = false;
        origami1.GetComponent<MeshRenderer>().enabled = true;
    }

    void Origami2ReloadToFirst()
    {
        origami2.SetActive(false);
        origami2.GetComponent<Origami2>().enabled = false;
        origami2.GetComponent<MeshRenderer>().enabled = true;
        origami2.GetComponent<Origami2>().t = 0;
    }
}