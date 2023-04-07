using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public enum EquipmentSlot { Head, Gloves, Weapon, Chest, Feet, ID }
    public EquipmentDollManager EquipUIDoll;
    public GameObject[] defaultEquipment; // Default equipment to fill the enum if relevant bool is checked
    public GameObject[] currentEquipment; // Current equipped equipment
    public bool[] isDefaultEquipped; // Boolean array to keep track of whether the default equipment is equipped
                                     //    public Transform[] equipmentParent; // Parent objects to attach equipment gameobjects to
    public static EquipmentManager instance;
    public CharStats Character;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            instance.EquipUIDoll = EquipUIDoll;
            instance.Character = Character;
        }
    }

    void Start()
    {
        currentEquipment = new GameObject[System.Enum.GetNames(typeof(EquipmentSlot)).Length];
        // Fill the current equipment array with default equipment if the relevant bool is checked
        for (int i = 0; i < defaultEquipment.Length; i++)
        {
            if (defaultEquipment[i] != null && isDefaultEquipped[i])
            {
                Equip(defaultEquipment[i], (EquipmentSlot)i);
            }
        }
    }

    public void Equip(GameObject equipment, EquipmentSlot slot)
    {
        int slotIndex = (int)slot;
        Unequip(slot);

        if (currentEquipment[slotIndex] != null)
        {
            Debug.LogWarning("Equipping " + equipment.name + " to " + slot.ToString() + " while " + currentEquipment[slotIndex].name + " is equipped. Unequipping " + currentEquipment[slotIndex].name);
        }
        GameObject newEquipment = Instantiate(equipment, transform);
        currentEquipment[slotIndex] = newEquipment;
        EquipUIDoll.EquipDollItem(slotIndex, newEquipment);
    }

    public void Unequip(EquipmentSlot slot)
    {
        int slotIndex = (int)slot;

        if (currentEquipment[slotIndex] != null)
        {
            GameObject oldEquipment = Instantiate(currentEquipment[slotIndex], Character.transform.position + Vector3.up * 1.5f + Character.transform.forward * .5f, Quaternion.identity);
            oldEquipment.transform.localScale = Vector3.one;

            //this is needed because the default equipments are not properly picked up
            if (oldEquipment.gameObject.GetComponent<Rigidbody>() == null)
                oldEquipment.gameObject.AddComponent<Rigidbody>();
            oldEquipment.GetComponent<Collider>().isTrigger = false;
            oldEquipment.GetComponent<Equipment>().ModifyStatsOnEquip(-1, Character);
            Destroy(currentEquipment[slotIndex]);
            currentEquipment[slotIndex] = null;


        }
    }
}