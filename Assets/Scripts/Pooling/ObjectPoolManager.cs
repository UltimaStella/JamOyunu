using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize;
    public static ObjectPoolManager instance;
    private List<GameObject> pooledObjects = new List<GameObject>();
    private ObjectFactory factory;



    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
        factory = new ObjectFactory(prefab, transform);

        for (int i = 0; i < poolSize; i++)
        {
            GameObject newObj = factory.CreateObject();
            newObj.SetActive(false);
            pooledObjects.Add(newObj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                // Call a method to handle object initialization if needed
                obj.GetComponent<IPooledObject>()?.OnObjectSpawn();
                return obj;
            }
        }

        // If no inactive objects are found, create a new one
        GameObject newObj = factory.CreateObject();
        pooledObjects.Add(newObj);
        return newObj;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        // Call a method to handle object cleanup if needed
        obj.GetComponent<IPooledObject>()?.OnObjectDespawn();
    }
}
