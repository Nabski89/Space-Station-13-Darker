using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour, IInteractable
{

    [field: SerializeField] public float InteractionTime { get; private set; }
    public float HarvestRequirement;
    public GameObject Seeds;
    public GameObject Crop;
    public bool HarvestReady = false;
    public bool Dead = false;
    HydroponicsTray Tray;

    // Update is called once per frame
    void Start()
    {
        Tray = GetComponentInParent<HydroponicsTray>();
        Tray.TrayPlanted = true;
        Tray.PlantHealth = 100;
        Tray.HarvestReq = HarvestRequirement;
    }


    public void Interact(Interact source, CharController Character)
    {
        Character.busy = false;
        if (Dead == true)
        {
            GetComponentInParent<RepeatReset>().Reset();
            Tray.TrayPlanted = false;
            Destroy(gameObject);
        }
        if (HarvestReady == true)
        {
            Instantiate(Seeds, transform.position + transform.up + (0.5f * transform.right), transform.rotation);
            Instantiate(Crop, transform.position + transform.up - (0.5f * transform.right), transform.rotation);
            GetComponentInParent<RepeatReset>().Reset();
            Tray.TrayPlanted = false;
            Tray.Reset();
            Destroy(gameObject);
        }
    }
    //when the plant dies make part of it black
    public void Die()
    {
        Dead = true;
        GetComponent<MeshRenderer>().material.color = Color.black;
    }
    public void Harvestable()
    {
        if (HarvestReady == false)
        {
            float score = 0;
            score += Tray.NoWaterTime / HarvestRequirement;
            score += Tray.NoFertTime / HarvestRequirement;
            score += Tray.NoPestTime / HarvestRequirement;

        }
        HarvestReady = true;
    }
}