﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class OpenBuildingsList : MonoBehaviour
{

    public GameObject Panel;
    public GameObject filterPanel;
    public GameObject button3d;
    public GameObject button3dChild;
    public GameObject buttonInfo;
    public GameObject buttonInfoChild;
    Image btn3d;
    Image btn3dChild;
    Image btnInfo;
    Image btnInfoChild;
    public SelectBuilding btnFlag;

    public BuildingsList buildList = new BuildingsList();
    public TimingsList timeList = new TimingsList();

    string[] mon = new string[12];

    

    int i = 0;

    private void Start()
    {
        //Debug.Log(Path.GetFileNameWithoutExtension("./Resources/buildingData"));
        button3d = GameObject.Find("button3D").gameObject;
        button3dChild = GameObject.Find("b3dchild").gameObject;
        buttonInfo = GameObject.Find("buttonInfo").gameObject;
        buttonInfoChild = GameObject.Find("bInfoChild").gameObject;

        btn3d = button3d.GetComponent<Image>();
        btn3dChild = button3dChild.GetComponent<Image>();
        btnInfo = buttonInfo.GetComponent<Image>();
        btnInfoChild = buttonInfoChild.GetComponent<Image>();

        Dictionary<string, List<string>[]> basicInfo = new Dictionary<string, List<string>[]>();
        List<string>[] buildingInfoCode = new List<string>[12];

        Dictionary<int, List<bool>[]> departmentInfo = new Dictionary<int, List<bool>[]>();
        List<bool>[] departmentInfoDetail = new List<bool>[12];

        Dictionary<int, List<bool>[]> facilitiesInfo = new Dictionary<int, List<bool>[]>();
        List<bool>[] facilitiesInfoDetail = new List<bool>[12];

        Dictionary<int, List<string>[]> timingInfo = new Dictionary<int, List<string>[]>();
        List<string>[] timingInfoDetail = new List<string>[12];

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
            for(int j=0; j<12; j++)
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
        if(Panel != null)
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
        if(Panel != null)
        {
            Panel.SetActive(false);
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
}
