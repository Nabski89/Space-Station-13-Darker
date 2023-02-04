using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    void Update()
    {
        {
            if (Input.GetMouseButtonDown(0))
            {
                UseConsumable();

            }
        }
    }


    void UseConsumable()
    {
        CharStats Stats = GetComponentInParent<CharStats>();
        Stats.HP += 5;
        GetComponentInParent<Inventory>().UseUpItem();

    }
}
