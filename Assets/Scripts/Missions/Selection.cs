using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Selection : MonoBehaviour
{

    GameObject selectedObject;
    public TextMeshProUGUI objNameText;
    private BuildingManager buildingManager;
    // Start is called before the first frame update
    void Start()
    {
        buildingManager = GameObject.Find("BuildManager").GetComponent<BuildingManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.gameObject.CompareTag("Build"))
                {
                    Select(hit.collider.gameObject);
                }
            }

        }
        if (Input.GetMouseButtonDown(1)&& selectedObject != null)
        {
            Deselect();
        }
    }

    private void Select(GameObject obj)
    {
        if (obj == selectedObject) return;
        if (selectedObject != null) Deselect();
        Outline outline = obj.GetComponent<Outline>();
        if (outline == null) obj.AddComponent<Outline>();
        else outline.enabled = true;
        objNameText.text = obj.name;
        selectedObject = obj;
    }


    private void Deselect()
    {
        selectedObject.GetComponent<Outline>().enabled = false;
        selectedObject = null;
    }

    public void Move()
    {
        selectedObject.layer = 9;
        buildingManager.pendingObject = selectedObject.transform.parent.gameObject;
        buildingManager.canPlace = true;
        buildingManager.canEscape = false;
    }
    public void Delete()
    {
        GameObject objToDestroy = selectedObject.transform.parent.gameObject;
        Deselect();
        Destroy(objToDestroy);
    }
}
