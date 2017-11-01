using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlopeUI : MonoBehaviour {

    public PlayerSlope pSlope;

    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = 
            pSlope.CurrentSlope.ToString() + 
            "\nCurrent State : " + pSlope.CurrentState() + 
            "\nPlay Count : " + Globals.Instance.playCount;
	}
}
