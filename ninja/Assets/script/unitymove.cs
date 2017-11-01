using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitymove : MonoBehaviour {
    public GameObject leftlegbox;
    public GameObject rightlegbox;

    public GameObject righthand;
    public GameObject lefthand;

    public KeyCode LeftCTRL;
    public KeyCode RightCTRL;

    public GameObject kosi;
    public GameObject ik;

    public float speed = 5;
    public float dspeed = -5;
    float downspeed;

    bool dashflag = false;

    public Rigidbody rig;

    public Animator legmove;

    public Animator kosimove;

    public float move;
    public float kmove = 1;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //leftlegbox.transform.localPosition = new Vector3(Input.GetAxis("Horizontal") - 0.2f, 0.2f , Input.GetAxis("Vertical"));
        //rightlegbox.transform.localPosition = new Vector3(Input.GetAxis("Horizontal2") + 0.2f, 0.2f, Input.GetAxis("Vertical2"));

        //kosimove.SetFloat("x", move);

        legmove.SetFloat("x", move);

        //Debug.Log(legmove.GetFloat("x"));
        //Debug.Log(kosimove.GetFloat("x"));

        kmove = 0.1f;

        

        if ((Input.GetButton("Vertical2"))== true)
        {
            //righthand.transform.position = new Vector3(-0.265f, 1, 0.172f);
            //ik.transform.position += new Vector3(0, 0, (Input.GetAxis("Vertical") + Input.GetAxis("Vertical2")) / 3);
            ik.transform.localEulerAngles += new Vector3(0, -1, kmove);

            if (move < 1)
            {
                move += 0.1f;
            }

            //righthand.transform.Rotate(0, 45, 0);
            dashflag = true;
        }

        if (Input.GetButton("Vertical") == true)
        {
            //ik.transform.position += new Vector3(0, 0, (Input.GetAxis("Vertical") + Input.GetAxis("Vertical2")) / 3);
            ik.transform.localEulerAngles +=new Vector3(0, 1, -kmove);

            if (move > -1 )
            {
                move -= 0.1f;
            }

            dashflag = true;
        }

        if(kosi.transform.rotation.z < 40)
        {
            //kosi.transform.Rotate(0, 0, Input.GetAxis("Vertical") / 2);
        }

        if (kosi.transform.rotation.z < -40)
        {
            //kosi.transform.Rotate(0, 0, -Input.GetAxis("Vertical2") / 2);
        }

        if(dashflag == true)
        {
            if(Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical2") > 0)
            {
                speed -= downspeed;
                downspeed += 0.01f;
                rig.velocity = (ik.transform.forward * (speed));
            }
            else if (Input.GetAxis("Vertical") < 0 || Input.GetAxis("Vertical2") < 0)
            {
                dspeed += downspeed;
                downspeed += 0.01f;
                rig.velocity = (ik.transform.forward * (dspeed));
            }
            //dashflag = false;
        }

        if (speed < 2 || dspeed > -2)
        {
            dashflag = false;
            speed = 5;
            dspeed = -5;
            downspeed = 0;
        }
    }
}
