using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player
{
    Player1, Player2
}

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private Player player;

    private string p;

	// Use this for initialization
	void Start () {

        switch (player)
        {
            case Player.Player1:
                p = "P1_";
                break;
            case Player.Player2:
                p = "P2_";
                break;
        }

    }
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis(p + "Horizontal") * Time.deltaTime * speed;
        var z = Input.GetAxis(p + "Vertical") * Time.deltaTime * speed;

        transform.Translate(x, 0, z);


        // FOR TESTING!!!!

        if (p == "P2_") return;
        if(Input.GetKey(KeyCode.D))
            transform.Rotate(0, 90 * Time.deltaTime, 0, Space.World);
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, -90 * Time.deltaTime, 0, Space.World);

    }
}
