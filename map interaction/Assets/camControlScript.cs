using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControlScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    private float yaw = 0.0f;
    private float pitch = 45.0f;
    public bool zoomed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomed == false)
        {
            Vector3 pos = transform.position;
            if (Input.GetMouseButton(1))
            {
                pos.x -= Input.GetAxis("Mouse X") * speed * Time.deltaTime;
                pos.z -= Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
            }
            transform.position = pos;
            if (Input.GetMouseButton(2))
            {
                yaw += rotationSpeed * Input.GetAxis("Mouse X");
                pitch -= rotationSpeed * Input.GetAxis("Mouse Y");
                transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
            }
        }
        
        
    }
}
