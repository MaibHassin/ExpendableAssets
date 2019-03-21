using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onclickScript : MonoBehaviour
{

    [SerializeField]
    private GameObject camNew;
    private Vector3 camOld;
    private Quaternion camRotation;
    [SerializeField]
    private GameObject camLocation;
    public MeshRenderer infoScreen;
    public MeshRenderer infoText;
    public bool zoomed = false;

    // Start is called before the first frame update
    void Start()
    {
        infoScreen.enabled = false;
        infoText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if(zoomed == false)
        {
            zoomed = true;
            camOld = camLocation.transform.position;
            camRotation = camLocation.transform.rotation;
            camLocation.transform.position = camNew.transform.position;
            camLocation.transform.rotation = Quaternion.Euler(-120, -130, 129);
            infoScreen.enabled = true;
            infoText.enabled = true;
        }
        else if(zoomed == true)
        {
            zoomed = false;
            camLocation.transform.position = camOld;
            camLocation.transform.rotation = camRotation;
            infoScreen.enabled = false;
            infoText.enabled = false;
        }
    }
}
