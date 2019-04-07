using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate3d : MonoBehaviour
{
    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;
    float mRotSpeed = 0.0f;
    public Camera mainCam;

    private void Start()
    {
        mainCam = GameObject.Find("3dCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        mPosDelta = Input.mousePosition - mPrevPos;
        if (Input.GetMouseButtonDown(0))

        {
            mRotSpeed = 1.0f;

            mPrevPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            mPosDelta = (Input.mousePosition - mPrevPos) / 8;
            if (Vector3.Dot(transform.up, Vector3.up) >= 0)
            {
                transform.Rotate(transform.up, -Vector3.Dot(mPosDelta, mainCam.transform.right), Space.World);
                mRotSpeed = 1.0f;
            }
            else
            {
                transform.Rotate(transform.up, Vector3.Dot(mPosDelta, mainCam.transform.right), Space.World);
                mRotSpeed = -1.0f;
            }
            transform.Rotate(mainCam.transform.right, Vector3.Dot(mPosDelta, mainCam.transform.up), Space.World);

            mPrevPos = Input.mousePosition;
        }
        //else
        //{
        //    mRotSpeed *= 0.99f;
        //    Vector3 updatedDelta = new Vector3(mPosDelta.x * mRotSpeed, mPosDelta.y * Mathf.Abs(mRotSpeed), 0.0f);
        //    transform.Rotate(mainCam.transform.right, Vector3.Dot(updatedDelta, mainCam.transform.up), Space.World);
        //    transform.Rotate(transform.up, -Vector3.Dot(updatedDelta, mainCam.transform.right), Space.World);
        //}
    }
}
