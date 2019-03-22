using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBuilding : MonoBehaviour
{
    private Button thisButton;
    GameObject buildingListPanel;
    GameObject searchButton;
    GameObject searchImage;
    GameObject searchText;
    public bool selected;
    GameObject buttonInfo;
    GameObject buttonInfoChild;
    GameObject button3d;
    GameObject button3dChild;
    string selectedButtonText;
    Image btn3d;
    Image btn3dChild;
    Image btnInfo;
    Image btnInfoChild;

    private Dictionary<string, Vector3> buildingPosition = new Dictionary<string, Vector3>();
    private string[] buildingCodes = { "DD05", "NB06", "ZE10", "ZP07", "ZP09", "ZP11", "ZP17", "ZP17a", "ZP23", "BB05" };
    private Vector3 buildingCoordinates = new Vector3();
    private Vector3 oldPosition = new Vector3();
    GameObject position;
    Camera myCamera;
    // Start is called before the first frame update
    void Start()
    {
        buildingListPanel = GameObject.FindGameObjectWithTag("Building List Panel").gameObject;
        searchButton = GameObject.Find("SearchBuildingButton").gameObject;
        searchImage = GameObject.Find("SearchImage").gameObject;
        searchText = GameObject.Find("SearchButtonText").gameObject;
        button3d = GameObject.Find("button3D").gameObject;
        button3dChild = GameObject.Find("b3dchild").gameObject;
        buttonInfo = GameObject.Find("buttonInfo").gameObject;
        buttonInfoChild = GameObject.Find("bInfoChild").gameObject;
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(() => actionBtn());

        btn3d = button3d.GetComponent<Image>();
        btn3dChild = button3dChild.GetComponent<Image>();
        btnInfo = buttonInfo.GetComponent<Image>();
        btnInfoChild = buttonInfoChild.GetComponent<Image>();

        myCamera = Camera.main;

        //for (int i=0; i<10; i++)
        //{
        //    position = GameObject.Find(buildingCodes[i]).gameObject;
        //    buildingCoordinates[i] = position.transform.position;
        //    Debug.Log(buildingCodes[i] + ":" + buildingCoordinates[i]);
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void actionBtn()
    {
        if (buildingListPanel != null)
        {
            buildingListPanel.SetActive(false);
            btn3d.enabled = !btn3d.enabled;
            btn3dChild.enabled = !btn3dChild.enabled;
            btnInfo.enabled = !btnInfo.enabled;
            btnInfoChild.enabled = !btnInfoChild.enabled;
        }
        if(searchImage != null)
        {
            searchImage.SetActive(false);
        }
        selectedButtonText = thisButton.GetComponentInChildren<Text>().text;
        searchText.GetComponent<Text>().text = selectedButtonText;

        oldPosition = myCamera.transform.position;
        position = GameObject.Find(selectedButtonText).gameObject;
        buildingCoordinates = position.transform.position;
        myCamera.transform.position = Vector3.Lerp(oldPosition, buildingCoordinates, 40 * Time.deltaTime);
        myCamera.orthographicSize = 50.0f;
    }
}
