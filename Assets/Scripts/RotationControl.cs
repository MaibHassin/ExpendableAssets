using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControl : MonoBehaviour
{
    public GameObject Obj = null;
    public float minY = -45.0f;
    public float maxY = 45.0f;

    public float sensX = 20.0f;
    public float sensY = 20.0f;

    float rotationY = 0.0f;
    float rotationX = 0.0f;

    public float rotationRate = 0.1f;

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            //Debug.Log("Touching at: " + touch.position);

            if (touch.phase == TouchPhase.Began && Input.touchCount > 2)
            {
                //Debug.Log("Touch phase began at: " + touch.position);
                //Camera.main.transform.eulerAngles = new Vector3(90, 0, 0);
                //Camera.main.transform.Rotate(90, 0, 0);
            }
            else if (touch.phase == TouchPhase.Moved && Input.touchCount == 3)
            {
                //Debug.Log("Touch phase Moved");
                Obj.transform.Rotate(touch.deltaPosition.y * 0,
                    -touch.deltaPosition.x * rotationRate, 0, Space.World);
            }
            else if (touch.phase == TouchPhase.Ended && Input.touchCount > 2)
            {
                //Debug.Log("Touch phase Ended " + Camera.main.transform.eulerAngles.x);
                //Camera.main.transform.Rotate(45, 0, 0);
                //Camera.main.transform.eulerAngles = new Vector3(45, 0, 0);
            }
        }
    }
}