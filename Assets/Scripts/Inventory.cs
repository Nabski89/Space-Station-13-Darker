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
        CheckConsumable();
        UpdateActiveSlot();
        UpdateDropping();

    }
    void CheckConsumable()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Consumable EatThis = GetComponentInChildren<Consumable>();
            if (EatThis != null)
                EatThis.UseConsumable();
        }
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

    float ThrowPower = 0;
    void UpdateDropping()
    {
        var item = Items[ActiveSlot];
        if (item == null) return;
        /*
        if (Input.GetMouseButtonDown(1))
        {
            item.gameObject.SetActive(true);
            item.transform.position = this.transform.position + Vector3.up * 1.5f + this.transform.forward * .5f; // xd i love hardcoding
            Rigidbody rb = item.gameObject.AddComponent<Rigidbody>();
            rb.AddForce(this.transform.forward * 300 + this.transform.up * 100);
            item.GetComponent<Collider>().isTrigger = false;
            //disable consumables
            if (item.GetComponent<Consumable>() != null)
                item.GetComponent<Consumable>().enabled = false;

            item.transform.rotation = Quaternion.identity;
            item.transform.parent = null;
            Items[ActiveSlot] = null;
            OnInventoryUpdated();
        }
*/
        if (Input.GetMouseButtonDown(1))
        {
            ThrowPower = 0;
        }
        if (Input.GetMouseButton(1))
        {
            if (ThrowPower < 3)
                ThrowPower += Time.deltaTime;
        }
        if (Input.GetMouseButtonUp(1))
        {
            item.gameObject.SetActive(true);
            item.transform.position = this.transform.position + Vector3.up * 1.5f + this.transform.forward * .5f; // xd i love hardcoding
            Rigidbody rb = item.gameObject.AddComponent<Rigidbody>();
            rb.AddForce((this.transform.forward * 300 + this.transform.up * 100) * ThrowPower / 3);
            item.GetComponent<Collider>().isTrigger = false;
            //disable consumables
            if (item.GetComponent<Consumable>() != null)
                item.GetComponent<Consumable>().enabled = false;

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
                //deal with consumables
                if (item.GetComponent<Consumable>() != null)
                {
                    Debug.Log("Picked up a consumable " + item.gameObject);
                    item.GetComponent<Consumable>().enabled = true;

                }
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