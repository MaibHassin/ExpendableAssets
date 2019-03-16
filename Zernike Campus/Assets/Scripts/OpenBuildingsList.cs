using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        button3d = GameObject.Find("button3D").gameObject;
        button3dChild = GameObject.Find("b3dchild").gameObject;
        buttonInfo = GameObject.Find("buttonInfo").gameObject;
        buttonInfoChild = GameObject.Find("bInfoChild").gameObject;

        btn3d = button3d.GetComponent<Image>();
        btn3dChild = button3dChild.GetComponent<Image>();
        btnInfo = buttonInfo.GetComponent<Image>();
        btnInfoChild = buttonInfoChild.GetComponent<Image>();
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
