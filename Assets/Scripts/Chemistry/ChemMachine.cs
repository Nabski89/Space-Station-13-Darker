using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemMachine : MonoBehaviour, IInteractable
{
    [field: SerializeField] public float InteractionTime { get; private set; }
    MoveButton Button;
    public ChemTank CTank;
    public int ChemicalNumber;
    // Start is called before the first frame update
    void Start()
    {
        Button = GetComponent<MoveButton>();
    }
    public void Interact(Interact source, CharController Character)
    {
        Character.busy = false;
        Button.enabled = true;
        CTank.Add(ChemicalNumber);
        Button.Push();
    }
}
