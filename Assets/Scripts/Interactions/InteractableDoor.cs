using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : MonoBehaviour, IInteractable
{

    public void Interact(Interact source, CharController Character)
    {
        Character.busy = false;
        this.GetComponentInParent<DoorScript>().DoorInteract();
    }
}