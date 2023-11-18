using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float spawnRate;
    private float lastSpawnTime;

    private void Start()
    {
        lastSpawnTime = Time.time;
    }

    private void Update()
    {
        if (lastSpawnTime + spawnRate < Time.time)
        {
            ObjectPoolManager.instance.GetPooledObject();
            lastSpawnTime = Time.time;
        }
    }


}
