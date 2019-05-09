using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingClick : MonoBehaviour
{
    public OpenBuildingsList OpenBuilding;


    private void OnMouseDown()
    {
        OpenBuilding.OpenInfoPanel();
    }
}
