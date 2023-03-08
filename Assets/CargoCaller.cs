using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoCaller : MonoBehaviour, IInteractable
{
    public CargoShuttle CargoShuttle;
    [field: SerializeField] public float InteractionTime { get; private set; }
    public void Interact(Interact source, CharController Character)
    {
        Character.busy = false;
        CargoShuttle.CallSend();

    }
}
