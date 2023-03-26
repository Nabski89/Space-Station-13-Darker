using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCookSelect : MonoBehaviour, IInteractable
{
    [field: SerializeField] public float InteractionTime { get; private set; }
    public NeedsItem CookMachine;
    public void Interact(Interact source, CharController Character)
    {
        if (Character != null)
            Character.busy = false;

        if (CookMachine.ItemRequired == 116) // if wheat make banana
        {
            transform.eulerAngles = new Vector3(180, 0, -90);
            CookMachine.ItemRequired = 111;
        }
        else
        {
            if (CookMachine.ItemRequired == 113)//if carrot make banana, else carrot
            {
                transform.eulerAngles = new Vector3(180, 0, 90);
                CookMachine.ItemRequired = 116;
            }
            else
            {
                transform.eulerAngles = new Vector3(180, 0, 180);
                CookMachine.ItemRequired = 113;
            }
        }
    }
}