using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : MonoBehaviour, IInteractable
{

    public void Interact(Interact source, CharController Character)
    {
        if (Character != null)
            Character.busy = false;
        this.GetComponentInParent<DoorScript>().DoorInteract();
    }
}