using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public Sprite Icon;

    public void Interact(Interact source, CharController Character)
    {
        Character.busy = false;
        var playerInventory = source.GetComponentInParent<Inventory>();
        playerInventory.TryPickup(this);
    }
}