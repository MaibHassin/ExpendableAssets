using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceFilter : MonoBehaviour
{
    public GameObject filterPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenFilterPanel()
    {
        if (filterPanel != null)
        {
            bool isActive = filterPanel.activeSelf;

            filterPanel.SetActive(!isActive);
        }
    }
}
