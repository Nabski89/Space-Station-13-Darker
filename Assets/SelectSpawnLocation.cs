using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSpawnLocation : MonoBehaviour
{
    public Vector3 StartLocation;


    // -4,0,1 for viro
    // -16,0,45 for assistant
    //115, 0 , 69 for engineer

    public void SelectLocation()
    {
        CharacterSelection.StartLocation = StartLocation;
    }
}