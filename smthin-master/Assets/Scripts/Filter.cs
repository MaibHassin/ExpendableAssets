using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filter : MonoBehaviour
{

    public float latitude;
    public float longitude;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        if(!Input.location.isEnabledByUser)
        {
            Debug.Log("GPS is not enabled");
            yield break;
        }

        Input.location.Start();
        int maxwait = 20;
        while(Input.location.status == LocationServiceStatus.Initializing && maxwait > 0)
        {
            yield return new WaitForSeconds(1);
            maxwait--;
        }

        if(maxwait<=0)
        {
            Debug.Log("Timed Out");
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
