using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMapControl : MonoBehaviour
{

    public float rotationSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 2)
        {
            Touch firstTouch = Input.GetTouch(0);

            Vector2 direction = Camera.main.ScreenToWorldPoint(firstTouch.position) - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Debug.Log("Angle: " + angle);

            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Debug.Log("rotation: " + rotation);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            transform.up = direction;
        }
    }
}
