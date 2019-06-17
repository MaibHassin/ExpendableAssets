using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingList : MonoBehaviour
{
    public GameObject listPanel;

    public void openPanel()
    {
        if(listPanel != null)
        {
            bool isActive = listPanel.activeSelf;
            listPanel.SetActive(!isActive);
        }
    }
}
