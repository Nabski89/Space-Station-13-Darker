using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeIntoStash : MonoBehaviour, IInteractable
{
    [field: SerializeField] public float InteractionTime { get; private set; }
    public GameObject StashedItem;

    public void Interact(Interact source, CharController Character)
    {
        if (StashCarryOver.StashedItem == null)
        {
            Inventory CharacterInventory = Character.GetComponent<Inventory>();
            if (CharacterInventory.Items[CharacterInventory.ActiveSlot] != null)
            {
                Item HeldItem = CharacterInventory.Items[CharacterInventory.ActiveSlot].GetComponent<Item>();
                if (HeldItem != null)
                {
                    StashCarryOver.StashedItem = Instantiate(HeldItem.gameObject, StashCarryOver.Instance.transform);
                    CharacterInventory.UseUpItem();
                    Chest TheChest = GetComponent<Chest>();
                    //    TheChest.enabled = true;
                    //    Destroy(this);
                }
            }
        }
        else
        {
            Instantiate(StashCarryOver.StashedItem, (transform.position + transform.up * 2), transform.rotation);
            Destroy(StashCarryOver.StashedItem);
            StashCarryOver.StashedItem = null;
        }
    }
}
