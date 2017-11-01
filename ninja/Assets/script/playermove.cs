using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour {
    public GameObject rootleft;
    public GameObject rootright;
    public Rigidbody playerrb;
    public float speed;
    public float accelaration;
    public int katamuki;
    public Animator leftanim;
    public Animator rightanim;
    public Animator kosi;
    public float downspeed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //float stickX = Input.GetAxisRaw("Horizontal2");
        Actmove();

        
    }

    void Actmove()
    {
        if(leftanim.GetFloat("leftmove") > 0 || rightanim.GetFloat("rightmove") > 0)
        {
            katamuki = 1;
            playerrb.AddForce(transform.forward * ((Input.GetAxis("Vertical") * 10) + (Input.GetAxis("Vertical2") * 10)));
            //playerrb.AddForce(transform.forward * ((Input.GetAxis("Vertical") * 10 * Time.deltaTime) + (Input.GetAxis("Vertical2") * 10 * Time.deltaTime)) / ( 60 * Time.deltaTime) , ForceMode.Acceleration);
            //transform.Rotate(0, (Input.GetAxis("Vertical") * 30 * Time.deltaTime) - (Input.GetAxis("Vertical2") * 30 * Time.deltaTime), 0);
            //Debug.Log();

        }
        else
        {
            katamuki = 0;
            
            

            if (downspeed == 0)
            {
                playerrb.velocity = transform.forward * 0;
                //downspeed = 10;
            }
            else
            {
                //playerrb.AddForce(transform.forward * -10);
                //downspeed -= 10 * Time.deltaTime;
            }
        }

        if( leftanim.GetFloat("leftmove") > 0)
        {
            transform.Rotate(0,-1f, 0);
            kosi.SetFloat("x", Input.GetAxis("Vertical"));
        }

        if (rightanim.GetFloat("rightmove") > 0)
        {
            transform.Rotate(0, 1f, 0);
            kosi.SetFloat("x", -Input.GetAxis("Vertical2"));
        }


        leftanim.SetFloat("leftmove", Mathf.Abs(Input.GetAxisRaw("Vertical")));
        rightanim.SetFloat("rightmove", Mathf.Abs(Input.GetAxisRaw("Vertical2")));


        if(kosi.GetFloat("x") != 0 || kosi.GetFloat("x") != 0)
        {
            katamuki = 1;
        }


        
    }
}
