using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    Item ItemBase;
    public EquipmentManager.EquipmentSlot equipmentSlot;
    public Sprite Icon;
    public float[] StatIncrease;
    public int Quality;
    //0 Strength
    //1 Agility
    //2 Knowledge
    //3 Resourcefullness
    //4 HP Max
    //5 Damage Mod
    //6 All Stats
    void Awake()
    {
        ItemBase = GetComponent<Item>();
        Icon = ItemBase.Icon;
    }
    void Start()
    {
        ItemBase.Quality = Random.Range(0, StatIncrease.Length);
        while (Quality < ItemBase.Quality)
        {
            int j = Random.Range(0, StatIncrease.Length);
            StatIncrease[j] += Mathf.Round(40 / (4 + StatIncrease[j])) / 10f;
            Quality += 1;
        }
    }
    public void Equip()
    {
        EquipmentManager.instance.Equip(transform.gameObject, equipmentSlot);
        ModifyStatsOnEquip(1, GetComponentInParent<CharStats>());
        GetComponentInParent<Inventory>().UseUpItem();
    }

    public void ModifyStatsOnEquip(int Equip, CharStats Char)
    {
        Char.Strength += (StatIncrease[0] * 3 + StatIncrease[6]) * Equip;
        Char.Agility += (StatIncrease[1] * 3 + StatIncrease[6]) * Equip;
        Char.Knowledge += (StatIncrease[2] * 3 + StatIncrease[6]) * Equip;
        Char.Resourcefulness += (StatIncrease[3] * 3 + StatIncrease[6]) * Equip;
        Char.HPMax += StatIncrease[4] * 5 * Equip;
        Char.CharDamageMod += StatIncrease[5] * 0.02f * Equip;
    }
}
