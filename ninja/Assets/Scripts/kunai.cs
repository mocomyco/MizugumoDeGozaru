using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kunai : MonoBehaviour {
    public float speed;//速さ
    float dellTime = 1.0f;
    private AudioSource Kunai;

    // Use this for initialization
    void Start () {
        Kunai = GameObject.Find("Kunai1").GetComponent<AudioSource>();
        Kunai.Play();
        transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.Translate(new Vector3(0,0,-1) * speed * Time.deltaTime);//移動
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "test")
        {

            Destroy(gameObject);//クナイ消去
        }

    }
}
