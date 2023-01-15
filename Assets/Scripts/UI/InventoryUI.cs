using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject ItemSlotPrefab;

    InventorySlotUI[] slots = new InventorySlotUI[Inventory.MAX_SLOTS];

    Inventory inventory;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>(); // If other players are ever added, would need a better way of distinguishing which player's inventory we care about

        for (int i = 0; i < Inventory.MAX_SLOTS; i++)
        {
            var go = Instantiate(ItemSlotPrefab, this.transform);
            slots[i] = go.GetComponent<InventorySlotUI>();
        }

        UpdateBars();
        inventory.InventoryUpdated += UpdateBars;
    }

    // Could probly do this without updating everything but without setting up a reactive library that would be effort
    void UpdateBars()
    {
        for (int i = 0; i < Inventory.MAX_SLOTS; i++)
        {
            slots[i].UpdateVisuals(inventory.Items[i], i == inventory.ActiveSlot);
        }
    }
}