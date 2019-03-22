using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class OpenBuildingsList : MonoBehaviour
{

    public GameObject Panel;
    public GameObject filterPanel;
    public GameObject panel3d;
    public GameObject infoPanel;

    public GameObject button3d;
    public GameObject button3dChild;
    public GameObject buttonInfo;
    public GameObject buttonInfoChild;
    public GameObject searchImg;
    GameObject searchTxt;
    Image btn3d;
    Image btn3dChild;
    Image btnInfo;
    Image btnInfoChild;
    public SelectBuilding btnFlag;

    public BuildingsList buildList = new BuildingsList();
    public TimingsList timeList = new TimingsList();

    string[] mon = new string[10];

    public Camera cameraMain;
    public Camera camera3d;

    public GameObject model3d = null;
    string buildingCodeText;
    Vector3 camera3dpos;

    int i = 0;

    private void Start()
    {
        //Debug.Log(Path.GetFileNameWithoutExtension("./Resources/buildingData"));
        searchTxt = GameObject.Find("SearchButtonText").gameObject;
        button3d = GameObject.Find("button3D").gameObject;
        button3dChild = GameObject.Find("b3dchild").gameObject;
        buttonInfo = GameObject.Find("buttonInfo").gameObject;
        buttonInfoChild = GameObject.Find("bInfoChild").gameObject;

        btn3d = button3d.GetComponent<Image>();
        btn3dChild = button3dChild.GetComponent<Image>();
        btnInfo = buttonInfo.GetComponent<Image>();
        btnInfoChild = buttonInfoChild.GetComponent<Image>();

        Dictionary<string, List<string>[]> basicInfo = new Dictionary<string, List<string>[]>();
        List<string>[] buildingInfoCode = new List<string>[10];

        Dictionary<int, List<bool>[]> departmentInfo = new Dictionary<int, List<bool>[]>();
        List<bool>[] departmentInfoDetail = new List<bool>[10];

        Dictionary<int, List<bool>[]> facilitiesInfo = new Dictionary<int, List<bool>[]>();
        List<bool>[] facilitiesInfoDetail = new List<bool>[10];

        Dictionary<int, List<string>[]> timingInfo = new Dictionary<int, List<string>[]>();
        List<string>[] timingInfoDetail = new List<string>[10];

        TextAsset asset = Resources.Load("BuildingsList") as TextAsset;
        TextAsset timeAsset = Resources.Load("BuildingTimings") as TextAsset;

        buildList = JsonUtility.FromJson<BuildingsList>(asset.text);
        timeList = JsonUtility.FromJson<TimingsList>(timeAsset.text);



        foreach(Buildings building in buildList.Buildings)
        {
            buildingInfoCode[i] = new List<string>();
            buildingInfoCode[i].Add(building.code);
            buildingInfoCode[i].Add(building.name);
            buildingInfoCode[i].Add(building.location);
            buildingInfoCode[i].Add(building.sections);
            basicInfo.Add(i.ToString(), buildingInfoCode);

            departmentInfoDetail[i] = new List<bool>();
            departmentInfoDetail[i].Add(building.departments.SABE);
            departmentInfoDetail[i].Add(building.departments.SABK);
            departmentInfoDetail[i].Add(building.departments.SAGZ);
            departmentInfoDetail[i].Add(building.departments.SASS);
            departmentInfoDetail[i].Add(building.departments.SAVK);
            departmentInfoDetail[i].Add(building.departments.SAVP);
            departmentInfoDetail[i].Add(building.departments.SCMI);
            departmentInfoDetail[i].Add(building.departments.SIBK);
            departmentInfoDetail[i].Add(building.departments.SIBS);
            departmentInfoDetail[i].Add(building.departments.SIEN);
            departmentInfoDetail[i].Add(building.departments.SIFE);
            departmentInfoDetail[i].Add(building.departments.SIFM);
            departmentInfoDetail[i].Add(building.departments.SILS);
            departmentInfoDetail[i].Add(building.departments.SIMM);
            departmentInfoDetail[i].Add(building.departments.SIRE);
            departmentInfoDetail[i].Add(building.departments.SISP);
            departmentInfoDetail[i].Add(building.departments.SITE);
            departmentInfoDetail[i].Add(building.departments.SEPA);
            departmentInfo.Add(i, departmentInfoDetail);

            facilitiesInfoDetail[i] = new List<bool>();
            facilitiesInfoDetail[i].Add(building.facilities.cafetaria);
            facilitiesInfoDetail[i].Add(building.facilities.ATM);
            facilitiesInfoDetail[i].Add(building.facilities.parking_meter);
            facilitiesInfoDetail[i].Add(building.facilities.library);
            facilitiesInfoDetail[i].Add(building.facilities.sitting_space);
            facilitiesInfoDetail[i].Add(building.facilities.printers);
            facilitiesInfoDetail[i].Add(building.facilities.bookable_room);
            facilitiesInfoDetail[i].Add(building.facilities.coffee_machine);
            facilitiesInfoDetail[i].Add(building.facilities.vending_machine);
            facilitiesInfo.Add(i, facilitiesInfoDetail);

            i++;
        }
        i = 0;
        foreach(Timings timing in timeList.Timings)
        {
            timingInfoDetail[i] = new List<string>();
            timingInfoDetail[i].Add(timing.monday);
            timingInfoDetail[i].Add(timing.tuesday);
            timingInfoDetail[i].Add(timing.wednesday);
            timingInfoDetail[i].Add(timing.thursday);
            timingInfoDetail[i].Add(timing.friday);
            timingInfoDetail[i].Add(timing.saturday);
            timingInfoDetail[i].Add(timing.sunday);
            timingInfo.Add(i, timingInfoDetail);

            i++;
        }


        List<string>[] buildingInfoResult;

        List<bool>[] departmentInfoResult;

        List<bool>[] facilitiesInfoResult;

        List<string>[] timingInfoResult;
        if(timingInfo.TryGetValue(0, out timingInfoResult) && basicInfo.TryGetValue("0", out buildingInfoResult) && departmentInfo.TryGetValue(0, out departmentInfoResult) && facilitiesInfo.TryGetValue(0, out facilitiesInfoResult))
        {
            for(int j=0; j<10; j++)
            {
                for(int k=0; k<4; k++)
                {
                    Debug.Log(buildingInfoResult[j][k]);
                }
                Debug.Log("<color=green>************************************************</color>");
                for (int k = 0; k < 18; k++)
                {
                    Debug.Log(departmentInfoResult[j][k]);
                }
                Debug.Log("<color=green>************************************************</color>");

                for (int k = 0; k < 9; k++)
                {
                    Debug.Log(facilitiesInfoResult[j][k]);
                }
                Debug.Log("<color=green>************************************************</color>");

                for (int k = 0; k < 7; k++)
                {
                    Debug.Log(timingInfoResult[j][k]);
                }
                Debug.Log("<color=red>************************************************</color>");
            }
        }
    }

    public void openPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
            if (btn3d.enabled)
            {
                btn3d.enabled = !btn3d.enabled;
                btn3dChild.enabled = !btn3dChild.enabled;
                btnInfo.enabled = !btnInfo.enabled;
                btnInfoChild.enabled = !btnInfoChild.enabled;
            }
        }
    }

    public void closePanel()
    {
        
        if (Panel != null)
        {
            Panel.SetActive(false);
            btn3d.enabled = false;
            btn3dChild.enabled = false;
            btnInfo.enabled = false;
            btnInfoChild.enabled = false;
            searchTxt.SetActive(false);
            searchImg.SetActive(true);
        }
    }

    public void openFilterPanel()
    {
        if(filterPanel != null)
        {
            filterPanel.SetActive(true);
        }
    }

    public void closeFilterPanel()
    {
        if (filterPanel != null)
        {
            filterPanel.SetActive(false);
        }
    }

    public void open3dPanel()
    {
        cameraMain.enabled = false;
        camera3d.enabled = true;
        camera3dpos = camera3d.transform.position;
        GenerateModel();
        if (panel3d != null)
        {
            panel3d.SetActive(true);
            if (btn3d.enabled)
            {
                btn3d.enabled = !btn3d.enabled;
                btn3dChild.enabled = !btn3dChild.enabled;
                btnInfo.enabled = !btnInfo.enabled;
                btnInfoChild.enabled = !btnInfoChild.enabled;
            }
        }
    }

    public void close3dPanel()
    {
        GameObject.Find("3dCamera").GetComponent<Camera>().enabled = false;
        GameObject.Find("Main Camera").GetComponent<Camera>().enabled = true;
        Destroy(GameObject.Find("building3d"));
        if (panel3d != null)
        {
            panel3d.SetActive(false);
            if (!btn3d.enabled)
            {
                btn3d.enabled = !btn3d.enabled;
                btn3dChild.enabled = !btn3dChild.enabled;
                btnInfo.enabled = !btnInfo.enabled;
                btnInfoChild.enabled = !btnInfoChild.enabled;
            }
        }
    }

    public void OpenInfoPanel()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(true);
            if (btn3d.enabled)
            {
                btn3d.enabled = !btn3d.enabled;
                btn3dChild.enabled = !btn3dChild.enabled;
                btnInfo.enabled = !btnInfo.enabled;
                btnInfoChild.enabled = !btnInfoChild.enabled;
            }
        }
    }

    public void CloseInfoPanel()
    {
        if(infoPanel != null)
        {
            infoPanel.SetActive(false);
            if (!btn3d.enabled)
            {
                btn3d.enabled = !btn3d.enabled;
                btn3dChild.enabled = !btn3dChild.enabled;
                btnInfo.enabled = !btnInfo.enabled;
                btnInfoChild.enabled = !btnInfoChild.enabled;
            }
        }
    }

    public void GenerateModel()
    {
        buildingCodeText = GameObject.Find("SearchButtonText").GetComponent<Text>().text;
        //model3d = GameObject.Find(buildingCodeText);
        model3d = Instantiate(GameObject.Find(buildingCodeText), camera3dpos, Quaternion.identity);
        model3d.name = "building3d";
        model3d.layer = 9;
        model3d.layer = LayerMask.NameToLayer("3dlayer");
        foreach(Transform trans in model3d.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = 9;
        }
        model3d.AddComponent<Rotate3d>();
    }
}
