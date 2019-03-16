using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LegendTouchAndHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    public GameObject infoPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPressed)
        {
            if(infoPanel != null)
            {
                infoPanel.SetActive(false);
            }
            return;
        }

        if(infoPanel != null)
        {
            infoPanel.SetActive(true);
        }
        Debug.Log("Pressed");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
