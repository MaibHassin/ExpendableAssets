using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;

public class RotateView : MonoBehaviour
{
    public Transform target;
    private Vector3 cameraOffset;
    //public float cameraFollowSpeed = 1.0f;
    private RotateGestureRecognizer rotategesture;
    public float cameraRotationSpeed = 1.0f;

    private void Start()
    {
        //SetCamera();
        SetupGesture();
    }

    private void LateUpdate()
    {
        Vector3 targetCameraPosition = target.position + cameraOffset;
        //transform.position = Vector3.Lerp(transform.position, targetCameraPosition, cameraFollowSpeed * Time.deltaTime);
    }


    void SetupGesture()
    {
        rotategesture = new RotateGestureRecognizer();
        rotategesture.Updated += RotateGestureCallBack;
        FingersScript.Instance.AddGesture(rotategesture);
    }

    void RotateGestureCallBack(GestureRecognizer gesture, ICollection<GestureTouch> touches)
    {
        if(gesture.State == GestureRecognizerState.Executing)
        {
            transform.RotateAround(target.position, Vector3.up, rotategesture.RotationDegreesDelta * cameraRotationSpeed);
        }
        //SetCamera();
    }

    //void SetCamera()
    //{
    //    transform.LookAt(target.position);
    //    cameraOffset = transform.position - target.position;
    //}
}
