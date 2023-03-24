using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoOpenDoor : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {


        InteractableDoor Door = other.gameObject.GetComponent<InteractableDoor>();
        if (Door != null)
        Door.Interact(null, null);
    }
}
