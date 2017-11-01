using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float cameraResetSpeed;
    [SerializeField] private KeyCode leftRotateKey;
    [SerializeField] private KeyCode rightRotateKey;
    [SerializeField] private KeyCode PS4leftRotateKey;//new Created
    [SerializeField] private KeyCode PS4rightRotateKey;//


    private bool needToReset = false;
    private float rotationAngle;
    private float resetAngleOffset = 1.0f;

    // Use this for initialization
    void Start () {

	}

    // Update is called once per frame
    void Update() {
        rotationAngle = ClampAngle(transform.localEulerAngles.y);
        
        if (transform.parent.hasChanged)
        {
            needToReset = true;
            transform.parent.hasChanged = false;
        }

        CheckInput();
        
        if (!needToReset)
            return;
        else
            transform.rotation = Quaternion.Slerp(transform.rotation, 
                transform.parent.rotation, Time.deltaTime * cameraResetSpeed);

        if (rotationAngle >= -resetAngleOffset 
            && rotationAngle <= resetAngleOffset)
            needToReset = false;
    }

    private float ClampAngle(float angle)
    {
        if (angle > 180) return angle -= 360;

        return angle;
    }

    private void CheckInput()
    {
        float step;

        if (Input.GetKey(leftRotateKey)|| Input.GetKey(PS4leftRotateKey)) step = -1;
        else if (Input.GetKey(rightRotateKey)||Input.GetKey(PS4rightRotateKey)) step = 1;
        else return;

        step *= rotationSpeed * Time.deltaTime;

        transform.RotateAround(transform.position, transform.up, -step);
        needToReset = false;
    }
}
