using UnityEngine;
using System.Collections;

public class JaponicaNote : MonoBehaviour {

    public GameObject
        fallPhoto,
        origami1;
    

   bool fly ;
  
    // Update is called once per frame
    void Update() {

        if (fly)
            {
                StartCoroutine("MovingToY");
            }

        JaponicaNoteToOrigamiAction();

        if (fallPhoto.gameObject ==null)
        {
            fly = true;
        }

    }

    void JaponicaNoteToOrigamiAction()
    {
        if (this.transform.position.y >= 3.5f)
        {

            Destroy(this.gameObject);
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
}
