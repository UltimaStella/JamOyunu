using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;
using System;
using Assets.Scripts.Controller;
public class BuildingManager : MonoBehaviour
{

    public GameObject[] objects;
    public GameObject pendingObject;
    [NonSerialized] public GameObject lastHittedObject;
    [SerializeField] Material[] materials;
    private Vector3 pos;
    public GameObject panel;
    private RaycastHit hit;
    private GameManager gm;
    [SerializeField] private LayerMask layerMask;

    public float rotateAmoun;
    public bool canPlace;
    public bool canEscape = true;
    public float gridSize;
    bool gridOn;
    [SerializeField] private Toggle gridToggle;

    private void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


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

            if (Input.GetKeyDown(KeyCode.Escape))
                DestroyPending();
        }

    }


    void DestroyPending()
    {
        if (canEscape)
        {
            Destroy(pendingObject);
            pendingObject = null;
            panel.SetActive(true);
        }
    }


    public void PlaceObject()
    {
        pendingObject.GetComponent<Renderer>().material = materials[2];
        if (lastHittedObject != null)
        {

            pendingObject.transform.parent = lastHittedObject.transform;
            pendingObject.GetComponent<Collider>().enabled = false;
            pendingObject.transform.localPosition = Vector3.zero;
            lastHittedObject.GetComponent<BuildController>().targetLevel =
                pendingObject.GetComponent<PersonController>().targetLevel;
        }
        pendingObject.layer = 0;
        pendingObject = null;
        lastHittedObject = null;
        panel.SetActive(true);
        canEscape = true;

    }
    public void SelectObject(int index)
    {
        if (!HasEnoughEnergy(index))
            return;

        pendingObject = Instantiate(objects[index]);
        if (index > 3)
            canPlace = false;
        panel.SetActive(false);
    }
    public bool HasEnoughEnergy(int index)
    {
        switch (index)

        {
            case 4:
                if (gm.currentEnergy >= 30)
                {
                    gm.currentEnergy -= 30;
                    return true;
                }
                break;
            case 5:
                if (gm.currentEnergy >= 60)
                {

                    gm.currentEnergy -= 60;
                    return true;
                }
                break;
            case 6:

                if (gm.currentEnergy >= 90)
                {

                    gm.currentEnergy -= 90;
                    return true;
                }
                break;
            case 7:

                if (gm.currentEnergy >= 150)
                {

                    gm.currentEnergy -= 150;
                    return true;
                }
                break;
            default:

                return true;

        }
        return false;


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
