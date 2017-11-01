using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RigidVelocity : MonoBehaviour {
    public Rigidbody rig;
    public Text velocity;
    public Text magnitude;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log("速度ベクトル" + rig.velocity);
        //Debug.Log("速度" + rig.velocity.magnitude);
    }

    
}
