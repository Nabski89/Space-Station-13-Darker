using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
 
    public float InteractionTime { get; }
    public void Interact(Interact source, CharController Character);
}