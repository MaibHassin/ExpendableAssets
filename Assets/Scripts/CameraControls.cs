using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour
{
    public float speed = 300.0f;//easing speed
    public float easingDistance = -10.0f;

    Vector3 hit_position = Vector3.zero;
    Vector3 current_position = Vector3.zero;
    Vector3 camera_position = Vector3.zero;
    float z = 0.0f;

    bool flag = false;
    Vector3 target_position;

    void Start()
    {
    }

    void Update()
    {
        CameraPan();
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
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -205.0f, 87.0f),
                Mathf.Clamp(transform.position.y, 445.0f, 613.0f),
                Mathf.Clamp(transform.position.z, -502.0f, -292.0f)
                );
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