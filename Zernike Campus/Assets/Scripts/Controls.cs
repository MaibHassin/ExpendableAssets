﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) //if one or more finger is on screen and the finger moved then
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition; //get the touch position
            transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0); //move camera in opposite direction of drag


            //boundaries for camera to stay in
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -950.0f, 1547.0f),
                Mathf.Clamp(transform.position.y, 984.0f, 1589.0f),
                Mathf.Clamp(transform.position.z, -3603.94f, -3603.94f));
        }
    }
}