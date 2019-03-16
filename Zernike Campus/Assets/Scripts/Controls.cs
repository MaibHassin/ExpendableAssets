using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controls : MonoBehaviour
{

    public float speed; //panning speed


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved) //if one or more finger is on screen and the finger moved then
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition; //get the touch position
                transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0); //move camera in opposite direction of drag


                //boundaries for camera to stay in
                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, -814.0f, 1400.0f),
                    Mathf.Clamp(transform.position.y, 1190.0f, 1347.0f),
                    Mathf.Clamp(transform.position.z, -3603.94f, -3603.94f));
            }
            else if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float previousTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                float deltaMagDiff = previousTouchDeltaMag - touchDeltaMag;

                Camera.main.fieldOfView += deltaMagDiff * 0.1f;

                Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 25.0f, 100.0f);
            }
        }
    }
}
