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
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Build"))
        {
            buildingManager.canPlace = false;
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Build"))
        {
            buildingManager.canPlace = true;
        }
    }
}
