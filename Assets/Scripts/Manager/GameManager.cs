using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{

    public float spawnRate;
    [SerializeField] private TextMeshProUGUI energyText;
    [SerializeField] private TextMeshProUGUI fuelText;
    [SerializeField] private Slider energySlider;
    public GameObject gameOverPanel;

    private float lastSpawnTime;
    private float lastUseFuel;
    int maxFuel = 200;

    int maxEnergy;

  public float currentEnergy;
    private float currentFuel;

    private void Start()
    {
     
        currentEnergy = 300;
        currentFuel = 200;

        maxFuel = 200;
        maxEnergy = 600;

        lastSpawnTime = Time.time;
        lastUseFuel = Time.time;
    }

    private void Update()
    {
        SpawnNpc();

    }

    private void LateUpdate()
    {
        ShowOnUI();
        DecreaseFuel();
    }
    void SpawnNpc()
    {
        if (lastSpawnTime + spawnRate < Time.time)
        {
            ObjectPoolManager.instance.GetPooledObject();
            lastSpawnTime = Time.time;
        }
    }

    void DecreaseFuel()
    {
        if (lastUseFuel + 2 < Time.time)
        {
            currentFuel--;
            lastUseFuel = Time.time;
            if (currentEnergy <= 0 || currentFuel <= 0) GameOver();

        }
    }
    void ShowOnUI()
    {
        energyText.text = currentEnergy.ToString();
        fuelText.text = currentFuel.ToString();
        energySlider.value = currentFuel / maxFuel;
    }

    public void AddFuel(int newFuel)
    {
        currentFuel += newFuel;
        if (currentFuel > maxFuel)
        {
            currentFuel = maxFuel;
        }
    }
    public void AddEnergy(int newEnergy)
    {

        currentEnergy += newEnergy;
        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
    public void SetRate(float rate )
    {
        spawnRate = rate;
    }
}
