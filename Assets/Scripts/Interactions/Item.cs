using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public Sprite Icon;

    public void Interact(Interact source)
    {
        var playerInventory = source.GetComponentInParent<Inventory>();
        playerInventory.TryPickup(this);
    }
}