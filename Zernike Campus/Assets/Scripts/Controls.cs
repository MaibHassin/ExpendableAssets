using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controls : MonoBehaviour
{

    public float pspeed; //panning speed

    public float speed = 250.0f;//easing speed
    public float easingDistance = -4.0f;

    Vector3 hit_position = Vector3.zero;
    Vector3 current_position = Vector3.zero;
    Vector3 camera_position = Vector3.zero;
    float z = 0.0f;

    bool flag = false;
    Vector3 target_position;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved) //if one or more finger is on screen and the finger moved then
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition; //get the touch position
                transform.Translate(-touchDeltaPosition.x * pspeed, -touchDeltaPosition.y * pspeed, 0); //move camera in opposite direction of drag


                //boundaries for camera to stay in
                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, -215.0f, 37.0f),
                    Mathf.Clamp(transform.position.y, -160.0f, 250.0f),
                    Mathf.Clamp(transform.position.z, -57.205f, -57.205f));
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

                Camera.main.orthographicSize += deltaMagDiff * 0.1f;

                Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 35.0f, 100.0f);
            }
        }
    }

    void CameraPan()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit_position = Input.mousePosition;
            camera_position = transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            current_position = Input.mousePosition;
            LeftMouseDrag();
            flag = true;
        }

        if (flag)
        {
            transform.position = Vector3.MoveTowards(transform.position, target_position, Time.deltaTime * speed);
            //transform.position = new Vector3(
            //    Mathf.Clamp(transform.position.x, -247.0f, 48.0f),
            //    Mathf.Clamp(transform.position.y, 200.0f, 400.0f),
            //    Mathf.Clamp(transform.position.z, -271.0f, -75.0f)
            //    );
            if (transform.position == target_position)//reached?
            {
                flag = false;// stop moving
            }
        }
    }

    void LeftMouseDrag()
    {
        // From the Unity3D docs: "The z position is in world units from the camera."  In my case I'm using the y-axis as height
        // with my camera facing back down the y-axis.  You can ignore this when the camera is orthograhic.
        //current_position.z = hit_position.z = camera_position.y;

        // Get direction of movement.  (Note: Don't normalize, the magnitude of change is going to be Vector3.Distance(current_position-hit_position)
        // anyways.  
        Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);

        // Invert direction to that terrain appears to move with the mouse.
        direction = direction * easingDistance;

        target_position = camera_position + direction;
    }

}
