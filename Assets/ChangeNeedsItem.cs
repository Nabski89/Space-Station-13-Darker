using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNeedsItem : MonoBehaviour
{
    public NeedsItem Modified;
    public int NewItemRequired;
    public bool NewObjectOneTimeUse;
    public GameObject NewWhatHappens;
    // Start is called before the first frame update
    void Start()
    {
        Modified.ItemRequired = NewItemRequired;
        Modified.ObjectOneTimeUse = NewObjectOneTimeUse;
        Modified.WhatHappens = NewWhatHappens;
        Destroy(this);
    }
}
