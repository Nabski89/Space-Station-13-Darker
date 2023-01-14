using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractOnObj : MonoBehaviour
{
    public GameObject SoundEffect;
    public void Interact()
    {
        if (SoundEffect != null)
            Instantiate(SoundEffect);
     //   Destroy(gameObject);
        if (GetComponentInParent<DoorScript>() != null)
            GetComponentInParent<DoorScript>().DoorInteract();
    }
}
