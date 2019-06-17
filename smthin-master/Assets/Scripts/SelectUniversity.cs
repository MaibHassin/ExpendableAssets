using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUniversity : MonoBehaviour
{
    public GameObject[] tags;

    public Material matHanze;
    public Material matRug;

    public GameObject canvas;

    public void SelectHanze()
    {
        tags = GameObject.FindGameObjectsWithTag("hanze");

        foreach (GameObject tagged in tags)
        {
            tagged.GetComponent<Renderer>().material = matHanze;
        }

        tags = GameObject.FindGameObjectsWithTag("both");

        foreach (GameObject tagged in tags)
        {
            tagged.GetComponent<Renderer>().material = matHanze;
        }

        tags = GameObject.FindGameObjectsWithTag("rug");

        foreach (GameObject tagged in tags)
        {
            tagged.GetComponent<Renderer>().material = matRug;
        }

        if(canvas != null)
        {
            bool isActive = canvas.activeSelf;
            canvas.SetActive(!isActive);
        }
    }

    public void SelectRug()
    {
        tags = GameObject.FindGameObjectsWithTag("hanze");

        foreach (GameObject tagged in tags)
        {
            tagged.GetComponent<Renderer>().material = matHanze;
        }

        tags = GameObject.FindGameObjectsWithTag("both");

        foreach (GameObject tagged in tags)
        {
            tagged.GetComponent<Renderer>().material = matRug;
        }

        tags = GameObject.FindGameObjectsWithTag("rug");

        foreach (GameObject tagged in tags)
        {
            tagged.GetComponent<Renderer>().material = matRug;
        }

        if (canvas != null)
        {
            bool isActive = canvas.activeSelf;
            canvas.SetActive(!isActive);
        }
    }
}
