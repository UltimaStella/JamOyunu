using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class BuildingManager : MonoBehaviour
{

    public GameObject[] objects;

    private Vector3 pos;

    private RaycastHit hit;

    [SerializeField] private LayerMask layerMask;


    private void FixedUpdate()
    {
        //Ray hit Camera.main.ScreenPointToRay(Input.)
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
