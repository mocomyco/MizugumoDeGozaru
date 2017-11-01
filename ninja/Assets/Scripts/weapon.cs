using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {
    public GameObject buki;
    public GameObject buki2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Act();
     
	}

    void Act() {
        //直進クナイ
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(buki, transform.position, transform.rotation);
        }

        //放物線クナイ
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(buki2, transform.position, transform.rotation);
        }

        
    }

 }
