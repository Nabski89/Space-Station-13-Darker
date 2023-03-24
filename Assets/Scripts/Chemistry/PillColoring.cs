using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillColoring : MonoBehaviour
{
    public int PillNumber = 1;

    MeshRenderer Pill;
    void Start()
    {
        Pill = GetComponent<MeshRenderer>();
        PillColor(0);
        PillColor(1);
        PillColor(2);
        Destroy(this);
    }

    void PillColor(int MatSlot)
    {
        int Selection = 0;
        switch (MatSlot)
        {
            case 0:
                Selection = (ChemTank.Recipe[PillNumber] / 10) % 10;
                break;
            case 1:
                Selection = ChemTank.Recipe[PillNumber] % 10;
                break;
            case 2:
                Selection = ChemTank.Recipe[PillNumber] / 100;
                break;
        }
        switch (Selection)
        {
            case 1:
                Pill.materials[MatSlot].color = Color.red;
                break;
            case 2:
                Pill.materials[MatSlot].color = Color.blue;
                break;
            case 3:
                Pill.materials[MatSlot].color = Color.green;
                break;
            case 4:
                Pill.materials[MatSlot].color = Color.yellow;
                break;
            case 5:
                Pill.materials[MatSlot].color = Color.magenta;
                break;
            case 6:
                Pill.materials[MatSlot].color = Color.white;
                break;
        }
    }
}
