using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kunai2 : MonoBehaviour {
    public float fspeed;//初速
    public float dspeed;//落下

    public float move;//移動距離

    float dellTime = 1.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //放物移動
        transform.position += new Vector3(0.0f, 2* fspeed * Time.deltaTime, 0.0f);//上昇
        fspeed -= dspeed * Time.deltaTime;//下降

        //横移動
        transform.Translate(Vector3.forward * move * Time.deltaTime);
    }

     void OnTriggerEnter(Collider hit)
     {
         if (hit.gameObject.tag == "test")
         {
             Destroy(gameObject);//クナイ消去
         }

     }

}
