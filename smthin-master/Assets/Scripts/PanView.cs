using UnityEngine;
using System.Collections;

public class PanView : MonoBehaviour
{
    public float panSpeed = 100.0f;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // get the touch position from the screen touch to world point
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                // lerp and set the position of the current object to that of the touch, but smoothly over time.
                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime * panSpeed);
                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, -100.0f, 100.0f),
                    Mathf.Clamp(transform.position.y, -2.0f, -2.0f),
                    Mathf.Clamp(transform.position.z, -100.0f, 100.0f));
            }
        }
    }
}