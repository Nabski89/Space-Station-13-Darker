using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : MonoBehaviour, IInteractable
{

    public void Interact(Interact source)
    {
        this.GetComponentInParent<DoorScript>().DoorInteract();
    }
}