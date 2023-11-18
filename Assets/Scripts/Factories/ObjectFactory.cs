using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory
{
    private GameObject prefab;
    private Transform parentTransform;

    public ObjectFactory(GameObject prefab, Transform parentTransform)
    {
        this.prefab = prefab;
        this.parentTransform = parentTransform;
    }

    public GameObject CreateObject()
    {
        GameObject newObj = GameObject.Instantiate(prefab, parentTransform);
        // You might need to adjust position, rotation, or other initial settings here
        return newObj;
    }
}

