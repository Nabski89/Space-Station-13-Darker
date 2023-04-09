using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StashCarryOver : MonoBehaviour
{
    public static GameObject[] StashedItem = new GameObject[1];

    public static StashCarryOver Instance;

        void Start()
    {
        Instance = this;
    }

}
