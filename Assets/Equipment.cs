using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    Item ItemBase;
    public EquipmentManager.EquipmentSlot equipmentSlot;
    public Sprite Icon;
    void Awake()
    {
        ItemBase = GetComponentInParent<Item>();
        Icon = ItemBase.Icon;
    }
    public void Equip()
    {
        EquipmentManager.instance.Equip(transform.gameObject, equipmentSlot);
        GetComponentInParent<Inventory>().UseUpItem();
    }
}
