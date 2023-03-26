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

        switch (ChemicalNumber+1)
        {
            case 1:
                GetComponent<MeshRenderer>().materials[0].color = new Vector4(0.63f, 0.31f, 0.67f, 1);
                break;
            case 2:
                GetComponent<MeshRenderer>().materials[0].color = new Vector4(0.72f, 0.43f, 0.43f, 1);
                break;
            case 3:
                GetComponent<MeshRenderer>().materials[0].color = new Vector4(0.44f, 0.43f, 0.73f, 1);
                break;
            case 4:
                GetComponent<MeshRenderer>().materials[0].color = new Vector4(0.66f, 0.69f, 0.28f, 1);
                break;
            case 5:
                GetComponent<MeshRenderer>().materials[0].color = new Vector4(0.31f, .6f, 0.39f, 1);
                break;
            case 6:
                GetComponent<MeshRenderer>().materials[0].color = Color.black;
                break;
        }
    }
    public void Interact(Interact source, CharController Character)
    {
        Character.busy = false;
        Button.enabled = true;
        CTank.Add(ChemicalNumber);
        Button.Push();
    }
}
