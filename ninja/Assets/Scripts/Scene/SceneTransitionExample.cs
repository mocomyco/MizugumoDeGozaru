using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionExample : MonoBehaviour {

    public string scene;
    public Color loadToColor = Color.white;
    public float fadeSpeed = 0.5f;

    public void ChangeScene()
    {
        Initiate.Fade(scene, loadToColor, fadeSpeed);
    }

}
