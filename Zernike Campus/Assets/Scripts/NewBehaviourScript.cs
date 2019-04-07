using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject myPrefab = null;
    // Start is called before the first frame update
    void Start()
    {
        myPrefab = GameObject.Find("ZP11");
        Instantiate(myPrefab, transform.position, Quaternion.identity);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
