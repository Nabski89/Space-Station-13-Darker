using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public void UseConsumable()
    {
        CharStats Stats = GetComponentInParent<CharStats>();
        Stats.HP += 5;
        GetComponentInParent<Inventory>().UseUpItem();
    }
}
