using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{
    public GameObject prefab;
    public GameObject buildingPanel;
    public int numberToCreate;
    private string[] buildingCodes = { "BB16", "DD05", "NB06", "ZE10", "ZL17", "ZP06", "ZP07", "ZP09", "ZP11", "ZP17", "ZP17a", "ZP23" };
    //Text buttonText;
    // Start is called before the first frame update
    void Start()
    {
        Populate();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Populate()
    {
        //buttonText = gameObject.GetComponent<Text>();
        GameObject[] newObj;
        newObj = new GameObject[numberToCreate];

        for (int i=0; i<numberToCreate; i++)
        {
            newObj[i] = (GameObject)Instantiate(prefab, transform);
            newObj[i].GetComponent<Button>();
            newObj[i].GetComponent<Button>().GetComponentInChildren<Text>().text = buildingCodes[i];
            newObj[i].GetComponent<Button>().name = "building " + buildingCodes[i];
            newObj[i].AddComponent<SelectBuilding>();
        }
    }
}
