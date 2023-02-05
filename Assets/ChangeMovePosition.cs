using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMovePosition : MonoBehaviour
{
    public GameObject WhatToMove;
    public Vector3 HowMuchToMove;
    // Start is called before the first frame update
    void Start()
    {
        WhatToMove.transform.position += HowMuchToMove;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
