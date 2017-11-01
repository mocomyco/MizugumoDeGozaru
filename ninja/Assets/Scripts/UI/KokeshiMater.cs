using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KokeshiMater : MonoBehaviour {
    public PlayerSlope _PSlope;
    private float KokeshiSlope;//こけしの傾き

	void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {
        KokeshiSlope = Keisan(_PSlope.CurrentSlope);//プレイヤーの傾きを代入
        gameObject.transform.rotation = Quaternion.Euler(0, 0, KokeshiSlope); 
	}

    public float Keisan(float val)
    {
        float Slope;
        Slope = val-100;//こけしのデフォ100
        return Slope;
    }
}
