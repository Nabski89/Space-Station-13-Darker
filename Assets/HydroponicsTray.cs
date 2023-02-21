using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydroponicsTray : MonoBehaviour
{
    public bool TrayPlanted = false;
    void Update()
    {
        if (TrayPlanted == true)
        {
            water();
            Fert();
            Pests();
            Health();
            Mature();
        }
    }
    public float Water = 100;
    public float WaterRate = 2;
    public MeshRenderer Beacon1;
    void water()
    {
        if (Water > -1)
        {
            Water -= Time.deltaTime * WaterRate;
            if (Water > 0)
            {
                {
                    Beacon1.material.color = Color.blue;
                }
            }
        }
    }
    public float Fertilizer = 20;
    public float FertilizerRate = 0.2f;
    public MeshRenderer Beacon2;
    void Fert()
    {
        if (Fertilizer > -1)
        {
            Fertilizer -= Time.deltaTime * FertilizerRate;
            if (Fertilizer > 0)
            {
                Beacon2.material.color = Color.yellow;
            }
        }
    }
    public float Pest = 100;
    public float PestsRate = 0.8f;
    public MeshRenderer Beacon3;
    void Pests()
    {
        if (Pest > -1)
        {
            Pest -= Time.deltaTime * PestsRate;
            if (Pest > 0)
            {
                Beacon3.material.color = Color.red;
            }
        }
    }
    public float PlantHealth = 20;
    public float PlantHealthRate = 0.2f;
    public MeshRenderer Beacon4;
    void Health()
    {
        if (PlantHealth > -1)
        {
            PlantHealth -= Time.deltaTime * PlantHealthRate;
            if (PlantHealth > 0)
            {
                GetComponentInChildren<Plant>().Dead = true;
                Beacon4.material.color = Color.red;
            }
        }
    }
    public float Harvest = 100;
    public float HarvestRate = 0.2f;
    public MeshRenderer Beacon5;
    void Mature()
    {
        if (Harvest > -1)
        {
            Harvest -= Time.deltaTime * HarvestRate;
            if (Harvest > 0)
            {
                GetComponentInChildren<Plant>().HarvestReady = true;
                Beacon5.material.color = Color.green;
            }
        }
    }
}
