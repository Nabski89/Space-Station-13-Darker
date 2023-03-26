using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemTankTopper : MonoBehaviour
{
    public float SpinSpeed = 0;
    void Update()
    {
        if (SpinSpeed > 0)
        {
            SpinSpeed -= 5 * Time.deltaTime;
            transform.Rotate(new Vector3(0, SpinSpeed, 0)); //applying rotation 
        }

    }
}
