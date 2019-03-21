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
    private camControlScript camScript;
    [SerializeField]
    private GameObject camLocation;
    public MeshRenderer infoScreen;
    public MeshRenderer infoText;

    // Start is called before the first frame update
    void Start()
    {
        infoScreen.enabled = false;
        infoText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Escape) && camScript.zoomed == true)
        {
            camScript.zoomed = false;
            camLocation.transform.position = camOld;
            camLocation.transform.rotation = camRotation;
            infoScreen.enabled = false;
            infoText.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if(camScript.zoomed == false)
        {
            camScript.zoomed = true;
            camOld = camLocation.transform.position;
            camRotation = camLocation.transform.rotation;
            camLocation.transform.position = camNew.transform.position;
            camLocation.transform.rotation = Quaternion.Euler(15, 180, 0);
            infoScreen.enabled = true;
            infoText.enabled = true;
        }
        
    }
}
