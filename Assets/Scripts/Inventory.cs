using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public const int MAX_SLOTS = 8;

    [SerializeField] GameObject[] HandPosition;

    public Item[] Items { get; } = new Item[MAX_SLOTS];
    public int ActiveSlot { get; private set; } = 0;

    public UnityAction InventoryUpdated = delegate { };

    void Update()
    {
        UpdateActiveSlot();
        UpdateDropping();

    }
    void UpdateActiveSlot()
    {
        for (int i = 0; i < MAX_SLOTS; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                ActiveSlot = i;
                OnInventoryUpdated();
                return;
            }
        }
    }

    void UpdateDropping()
    {
        var item = Items[ActiveSlot];
        if (item == null) return;
        if (Input.GetMouseButtonDown(1))
        {
            item.gameObject.SetActive(true);
            item.transform.position = this.transform.position + Vector3.up * 1.5f + this.transform.forward * .5f; // xd i love hardcoding
            Rigidbody rb = item.gameObject.AddComponent<Rigidbody>();
            rb.AddForce(this.transform.forward * 300 + this.transform.up * 100);
            item.GetComponent<Collider>().isTrigger = false;


            item.transform.rotation = Quaternion.identity;
            item.transform.parent = null;
            Items[ActiveSlot] = null;
            OnInventoryUpdated();
        }
    }
    public void UseUpItem()
    {
        var item = Items[ActiveSlot];
        if (item == null) return;
        Destroy(item.gameObject);
        Items[ActiveSlot] = null;
        OnInventoryUpdated();
    }

    public void TryPickup(Item item)
    {
        for (int i = 0; i < MAX_SLOTS; i++)
        {
            if (Items[i] == null)
            {
                Items[i] = item;
                item.gameObject.SetActive(false);
                OnInventoryUpdated();
                return;
            }
        }

        // If we hit this point, the inventory is full
    }

    public void OnInventoryUpdated()
    {
        for (int i = 0; i < MAX_SLOTS; i++)
        {
            var item = Items[i];
            if (item == null) continue;
            bool isActive = ActiveSlot == i;
            item.gameObject.SetActive(isActive);
            if (isActive)
            {
                item.transform.parent = HandPosition[item.GetComponent<Item>().WeaponType].transform;
                item.transform.localPosition = Vector3.zero;
                item.transform.localRotation = Quaternion.identity;
            }
        }
        InventoryUpdated(); // Send an event so that other things (namely the UI) can update too
    }
}