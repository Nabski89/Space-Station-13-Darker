using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLight : MonoBehaviour, IInteractable
{
    [field: SerializeField] public float InteractionTime { get; private set;}
    public int ChanceLightOutPercent = 0;
    public Light LightBulb;
    void Start()
    {
        if (Random.Range(0, 100) < ChanceLightOutPercent)
            ToggleLight();
    }
    public void Interact(Interact source, CharController Character)
    {
        Character.busy = false;
        ToggleLight();
    }

    void ToggleLight()
    {
        if (LightBulb.enabled == false)
            LightBulb.enabled = true;
        else
            LightBulb.enabled = false;
    }
}