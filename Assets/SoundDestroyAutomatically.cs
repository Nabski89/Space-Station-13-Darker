using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDestroyAutomatically : MonoBehaviour
{
    public int Lifetime = 5;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Lifetime);
    }

}
