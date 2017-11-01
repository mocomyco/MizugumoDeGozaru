using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSeni : MonoBehaviour {
    public float verticle; //横の傾き
    public float horizontal;//縦の傾き
    
    public float MaxVer = 100,MinVer = -100;//傾きの上限下限
    public float MaxHor = 100, MinHor = -100;
    private float contract = 200;
    public PlayerSlope PSlope;
    public GameObject body;
    public GameObject rightHand;
    public GameObject leftHand;
    private Vector3 IK;
	
	void Start () {
        // verticle = body.transform.localRotation.x;
        // horizontal = body.transform.localRotation.z;
        IK = PSlope.transform.position;
        verticle = body.transform.localPosition.x;
        horizontal = body.transform.localPosition.z;
	}
	
	// Update is called once per frame
	void Update () {
        verticle = (PSlope.SendDamageVec.x);
        horizontal = (PSlope.SendDamageVec.z);
        //Setting();
        //body.transform.localRotation = Quaternion.Euler(verticle,body.transform.rotation.y,horizontal);
        //body.transform.localPosition = new Vector3(-horizontal/contract, body.transform.localPosition.y, verticle/contract);
        body.transform.localRotation = Quaternion.Euler(verticle * 45, body.transform.rotation.y, horizontal * 45);
        body.transform.localPosition = Vector3.Lerp(Vector3.zero , body.transform.position, 1 * Time.deltaTime);
        //rightHand.transform.localPosition = new Vector3(0.5f, body.transform.localPosition.y, verticle / contract);
        //leftHand.transform.localPosition = new Vector3(-0.5f, body.transform.localPosition.y, verticle / contract);

    }

    public void Debugddd()
    {
        Debug.Log(body.transform.localPosition);
    }
    void Setting()
    {
        if (horizontal >= MaxHor) horizontal = MaxHor;
        if (horizontal <= MinHor) horizontal = MinHor;
        if (verticle >= MaxVer) verticle = MaxVer;
        if (verticle <= MinVer) verticle = MinVer;
    }

    void Damaged()
    {
        body.transform.position = IK + new Vector3(verticle, 0, horizontal);
    }
}
