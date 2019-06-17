using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSText : MonoBehaviour
{
    public Text coordinates;
    public Text timestamp;
    private void Update()
    {
        coordinates.text = "Lat:" + GPS.Instance.latitude.ToString() + "   Lon:" + GPS.Instance.longitude.ToString() + " - " + GPS.Instance.timest + " - " + GPS.Instance.va + " - " + GPS.Instance.ha + " - " + GPS.Instance.i;


    }
}
