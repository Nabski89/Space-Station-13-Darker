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
    public float WaterRate = 1;
    public float NoWaterTime = 0;
    public MeshRenderer Beacon1;
    void water()
    {
        Water -= Time.deltaTime * WaterRate;
        if (Water < 0)
        {
            Beacon1.material.color = Color.blue;
            NoWaterTime += Time.deltaTime;
        }
    }
    public float Fertilizer = 20;
    public float FertilizerRate = 1f;
    public float NoFertTime = 0;
    public MeshRenderer Beacon2;
    void Fert()
    {
        Fertilizer -= Time.deltaTime * FertilizerRate;
        if (Fertilizer < 0)
        {
            Beacon2.material.color = Color.yellow;
            NoFertTime += Time.deltaTime;
        }
    }
    public float Pest = 100;
    public float PestsRate = 0.8f;
    public float NoPestTime = 0;
    public MeshRenderer Beacon3;
    void Pests()
    {
        Pest -= Time.deltaTime * PestsRate;
        if (Pest < 0)
        {
            Beacon3.material.color = Color.red;
            NoPestTime += Time.deltaTime;
        }
    }
    public float PlantHealth = 20;
    public float PlantHealthRate = 0.2f;
    public MeshRenderer Beacon4;
    void Health()
    {
        if (PlantHealth > -1)
            PlantHealth -= Time.deltaTime * PlantHealthRate;
        if (PlantHealth < 0)
        {
            GetComponentInChildren<Plant>().Die();
            Beacon4.material.color = Color.red;
        }
    }
    public float Harvest = 100;
    public float HarvestReq = 100;
    public float HarvestRate = 0.2f;
    public MeshRenderer Beacon5;
    void Mature()
    {
        if (Harvest > -1)
            Harvest -= Time.deltaTime * HarvestRate;
        if (Harvest < 0)
        {
            GetComponentInChildren<Plant>().Harvestable();
            Beacon5.material.color = Color.green;
        }
    }

    public void Lights()
    {

    }

    public void Reset()
    {
        Beacon5.material.color = Color.black;

    }
}
