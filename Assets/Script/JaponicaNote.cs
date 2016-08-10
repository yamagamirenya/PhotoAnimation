using UnityEngine;
using System.Collections;

public class JaponicaNote : MonoBehaviour {

    public GameObject
        fallPhoto,
        origami1,
        origami3;

    FallPhoto fallPhotoScript;
   bool fly ;

    Vector3 firstPositon;
  
    void Start()
    {

        firstPositon = this.transform.position;
        fallPhotoScript = fallPhoto.GetComponent<FallPhoto>();
    }

    // Update is called once per frame
    void Update() {

        if (fly)
            {
                StartCoroutine("MovingToY");
            }

        JaponicaNoteToOrigamiAction();

        if (fallPhotoScript.japonicaAction )
        {
            fly = true;

            fallPhotoScript.japonicaAction = false;
        }

        if (origami1.activeInHierarchy)
        {
            this.transform.position = firstPositon;
            this.gameObject.SetActive(false);
            fly = false;

        }

        FinishToFirstScean();
    }

    void JaponicaNoteToOrigamiAction()
    {
        if (this.transform.position.y>=2.7f)
        {
            print("fafafaf");
           // this.gameObject.SetActive(false);
            origami1.SetActive(true);
            origami1.GetComponent<Origami>().enabled = true;

        }
    }

    IEnumerator MovingToY()
    {
        yield return new WaitForSeconds(3f);
        if (origami1)
        {

            float nowX = this.transform.position.x;
            float changeY = Mathf.Lerp(this.transform.position.y, origami1.transform.position.y, Time.deltaTime);
            float nowZ = this.transform.position.z;

            this.transform.position = new Vector3(nowX, changeY, nowZ);
        }
    }

    void FinishToFirstScean()
    {
        Origami3 origami3Script = origami3.GetComponent<Origami3>();

        if (origami3Script.blurOptimizedChange == true)
        {

            print("aaa");
            //this.transform.position = firstPositon;
           // this.gameObject.SetActive(true);


        }

    }
}
