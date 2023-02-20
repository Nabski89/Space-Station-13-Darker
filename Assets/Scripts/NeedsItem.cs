using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsItem : MonoBehaviour, IInteractable
{
    public int ItemRequired = 0;
    public bool ObjectOneTimeUse = false;
    public GameObject WhatHappens;

    //when interacting, check if the currently held item is a usable item. Then if the item number matches the required one, activate a different game object.
    //If the item can only be used once, then it and this is script is removed
    //If one object can create multiple things, set that up on the hand held object
    public void Interact(Interact source, CharController Character)
    {
        Character.busy = false;
        Inventory CharacterInventory = Character.GetComponent<Inventory>();
        UsableItem HeldItem = CharacterInventory.Items[CharacterInventory.ActiveSlot].GetComponent<UsableItem>();
        if (HeldItem != null)
        {
            if (HeldItem.ItemNumber == ItemRequired)
            {

                if (HeldItem.CustomHappening != null)
                {
                    Instantiate(HeldItem.CustomHappening, transform);
                }
                else
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
