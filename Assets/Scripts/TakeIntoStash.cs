using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeIntoStash : MonoBehaviour, IInteractable
{
    [field: SerializeField] public float InteractionTime { get; private set; }
    public GameObject StashedItem;

    public void Interact(Interact source, CharController Character)
    {
        if (StashCarryOver.StashedItem[0] == null)
        {
            Inventory CharacterInventory = Character.GetComponent<Inventory>();
            if (CharacterInventory.Items[CharacterInventory.ActiveSlot] != null)
            {
                Item HeldItem = CharacterInventory.Items[CharacterInventory.ActiveSlot].GetComponent<Item>();
                if (HeldItem != null)
                {
                    StashCarryOver.StashedItem[0] = Instantiate(HeldItem.gameObject, StashCarryOver.Instance.transform);
                    CharacterInventory.UseUpItem();
                    Chest TheChest = GetComponent<Chest>();
                    //    TheChest.enabled = true;
                    //    Destroy(this);
                }
            }
        }
        else
        {
            Instantiate(StashCarryOver.StashedItem[0], (transform.position + transform.up * 2), transform.rotation);
            Destroy(StashCarryOver.StashedItem[0]);
            StashCarryOver.StashedItem[0] = null;
        }
    }
}
