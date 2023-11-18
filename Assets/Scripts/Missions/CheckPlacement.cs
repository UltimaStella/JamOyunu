using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlacement : MonoBehaviour
{
    BuildingManager buildingManager;
    private void Start()
    {
        buildingManager = GameObject.Find("BuildManager").GetComponent<BuildingManager>();
       
    }
    private void Update()
    {
        GetComponent<Collider>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Build"))
        {
            buildingManager.canPlace = false;
        }
        if (other.gameObject.CompareTag("Person"))
        {
            if (transform.childCount > 1) return;

            buildingManager.canPlace = true;
            buildingManager.lastHittedObject = gameObject;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Build"))
        {
            buildingManager.canPlace = true;
        
        }
        if(other.gameObject.CompareTag("Person"))
        {
         
            buildingManager.canPlace = false;
            buildingManager.lastHittedObject = null;
        }
    }

}
