using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLight : MonoBehaviour, IInteractable
{
    public Light LightBulb;
    public void Interact(Interact source, CharController Character)
    {
        Character.busy = false;
        if (LightBulb.enabled == false)
            LightBulb.enabled = true;
        else
            LightBulb.enabled = false;
    }
}