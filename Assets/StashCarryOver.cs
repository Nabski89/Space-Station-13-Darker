using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StashCarryOver : MonoBehaviour
{
    public static GameObject StashedItem;

    public static StashCarryOver Instance;

        void Start()
    {
        Instance = this;
    }

}
