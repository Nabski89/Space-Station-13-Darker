using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : MonoBehaviour, IInteractable
{
    [field: SerializeField] public float InteractionTime { get; private set; }
    public void Interact(Interact source, CharController Character)
    {
        if (Character != null)
            Character.busy = false;
        this.GetComponentInParent<DoorScript>().DoorInteract();
    }
}