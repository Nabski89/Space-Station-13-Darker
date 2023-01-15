using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] Image Icon;
    [SerializeField] Image Border;

    public void UpdateVisuals(Item item, bool active)
    {
        Icon.sprite = item?.Icon;
        Icon.enabled = item != null;
        Border.color = new Color(1, 1, 1, active ? 0.8f : .1f); // xd hardcoding
    }
}