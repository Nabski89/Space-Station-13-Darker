using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsItem : MonoBehaviour, IInteractable
{
    public int ItemRequired = 0;
    public bool ObjectOneTimeUse = false;
    public GameObject WhatHappens;
    public void Interact(Interact source, CharController Character)
    {
        Character.busy = false;
        Inventory CharacterInventory = Character.GetComponent<Inventory>();
        UsableItem HeldItem = CharacterInventory.Items[CharacterInventory.ActiveSlot].GetComponent<UsableItem>();
        if (HeldItem != null)
        {
            if (HeldItem.ItemNumber == ItemRequired)
            {
                WhatHappens.SetActive(true);
                //do the thing
                if (HeldItem.OneTimeUse == true)
                    CharacterInventory.UseUpItem();
                if (ObjectOneTimeUse == true)
                    Destroy(this);
            }
        }
    }
}
