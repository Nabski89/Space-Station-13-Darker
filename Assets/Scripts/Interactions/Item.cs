using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public Sprite Icon;
    public Collider m_ObjectCollider;
    //This will be used to determine what attack type it falls under and assign it. Current max is three for 0Axe 1Dagger 2Sword
    public int WeaponType = 0;

    void Start()
    {
        m_ObjectCollider = GetComponent<Collider>();
        if (WeaponType > 2)
            WeaponType = 2;
    }
    public void Interact(Interact source, CharController Character)
    {
        Character.busy = false;
        var playerInventory = source.GetComponentInParent<Inventory>();

        m_ObjectCollider.isTrigger = true;
        Destroy(gameObject.GetComponent<Rigidbody>());

        playerInventory.TryPickup(this);
    }
}