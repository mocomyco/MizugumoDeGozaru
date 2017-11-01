using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVarsExample : MonoBehaviour {

	public void AddReplayCount()
    {
        Globals.Instance.playCount += 1;
    }
}
