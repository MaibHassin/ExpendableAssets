using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour
{
    public static GPS Instance { set; get; }

    public float latitude;
    public float longitude;
    public string timest;
    public int i = 0;
    public float va, ha;

    public Text enabled;
    public Text timedOut;
    public Text deviceLocation;
    public Text status;

    IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {

        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        coroutine = UpdateGPS();
        if (!Input.location.isEnabledByUser)
        {
            enabled.text = "GPS Enabled by user: false";
            yield break;
        }

        Input.location.Start();
        int maxwait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxwait > 0)
        {
            yield return new WaitForSeconds(1);
            maxwait--;
        }

        if (maxwait <= 0)
        {
            timedOut.text = "Timed out: true";
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            deviceLocation.text = "Location Services: Failed to determine device location";
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        timest = Input.location.lastData.timestamp.ToString();
        va = Input.location.lastData.verticalAccuracy;
        ha = Input.location.lastData.horizontalAccuracy;
        StartCoroutine(coroutine);
    }

    IEnumerator UpdateGPS()
    {
        float UPDATE_TIME = 1f;
        WaitForSeconds updateTime = new WaitForSeconds(UPDATE_TIME);
        
        while(true)
        {
            status.text = Input.location.status.ToString();

            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            timest = Input.location.lastData.timestamp.ToString();
            va = Input.location.lastData.verticalAccuracy;
            ha = Input.location.lastData.horizontalAccuracy;
            i++;
            yield return updateTime;
        }
    }
}
