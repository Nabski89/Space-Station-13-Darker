using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillColoring : MonoBehaviour
{
//our six pill colors ARE
//a150aa (a purple)     new Vector3(0.63f, 0.31f, 0.67f)
//b86d6d (Light Red)    new Vector3(0.72f, 0.43f, 0.43f)
//706db8 (Light Blue)   new Vector3(0.44f, 0.43f, 0.73f)
//a8b147 (Puky Yellow)  new Vector3(0.66f, 0.69f, 0.28f)
//4f9964 (A Green)      new Vector3(0.31f, .6f, 0.39f)
//BLACK                 Color.black


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
                            Debug.Log((ChemTank.Recipe[PillNumber] / 10) % 10);
                break;
            case 1:
                Selection = ChemTank.Recipe[PillNumber] % 10;
                Debug.Log(ChemTank.Recipe[PillNumber] % 10);
                break;
            case 2:
                Selection = ChemTank.Recipe[PillNumber] / 100;
                Debug.Log(ChemTank.Recipe[PillNumber] / 100);
                break;
        }
        switch (Selection)
        {
            case 1:
                Pill.materials[MatSlot].color = new Vector4(0.63f, 0.31f, 0.67f, 1);
                break;
            case 2:
                Pill.materials[MatSlot].color = new Vector4(0.72f, 0.43f, 0.43f, 1);
                break;
            case 3:
                Pill.materials[MatSlot].color = new Vector4(0.72f, 0.43f, 0.43f, 1);
                break;
            case 4:
                Pill.materials[MatSlot].color = new Vector4(0.66f, 0.69f, 0.28f, 1);
                break;
            case 5:
                Pill.materials[MatSlot].color = new Vector4(0.31f, .6f, 0.39f, 1);
                break;
            case 6:
                Pill.materials[MatSlot].color = Color.black;
                break;
        }
    }
}
