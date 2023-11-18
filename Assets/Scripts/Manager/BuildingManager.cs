using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{

    public GameObject[] objects;
    public GameObject pendingObject;
    [SerializeField] Material[] materials;

    private Vector3 pos;

    private RaycastHit hit;

    [SerializeField] private LayerMask layerMask;

    public float rotateAmoun;
    public bool canPlace;
    public float gridSize;
    bool gridOn;
    [SerializeField] private Toggle gridToggle;

    void UpdateMaterials()
    {
        if (canPlace) pendingObject.GetComponent<Renderer>().material = materials[0];
        else pendingObject.GetComponent<Renderer>().material = materials[1];

    }


    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            pos = hit.point;
        }

    }

    private void Update()
    {
        if (pendingObject != null)
        {
            if (gridOn)
            {
                pendingObject.transform.position = new Vector3(
                    RoundToNearestGrid(pos.x),
                    RoundToNearestGrid(pos.y),
                    RoundToNearestGrid(pos.z)
                    );
            }
            else pendingObject.transform.position = pos;


            if (Input.GetMouseButtonDown(0) && canPlace)
            {
                PlaceObject();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                RotateObject();
            }
            UpdateMaterials();
        }
    }

    public void PlaceObject()
    {
        pendingObject.GetComponent<Renderer>().material = materials[2];
        pendingObject = null;


    }
    public void SelectObject(int index)
    {
        pendingObject = Instantiate(objects[index], pos, transform.rotation);
    }

    public void ToggleGrid()
    {
        if (gridToggle.isOn) gridOn = true;
        else gridOn = false;
    }
    public float RoundToNearestGrid(float pos)
    {

        float xDiff = pos % gridSize;
        pos -= xDiff;

        if (xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;

    }
    public void RotateObject()
    {
        pendingObject.transform.Rotate(Vector3.up, rotateAmoun);
    }





}
