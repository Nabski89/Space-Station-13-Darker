using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSpace : MonoBehaviour
{
    public bool Outside = false;
    private void OnTriggerEnter(Collider other)
    {
        CharStats Char = other.GetComponent<CharStats>();
        if (Char != null)
        {
            Char.InSpace = Outside;
        }
    }
}
