using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotWaterComponent : MonoBehaviour
{
    HydroponicsTray Tray;
    void Start()
    {
        Tray = GetComponentInParent<HydroponicsTray>();
    }

    // Update is called once per frame
    void Update()
    {
        Tray.Water = 100;
        this.gameObject.SetActive(false);
    }
}
