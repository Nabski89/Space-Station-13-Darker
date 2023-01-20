using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public Sprite Icon;
    public Collider m_ObjectCollider;

    void Start()
    {
        m_ObjectCollider = GetComponent<Collider>();
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