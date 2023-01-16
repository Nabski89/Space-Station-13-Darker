using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLight : MonoBehaviour
{
    int CheckCounter = -1;
    RaycastHit hitWall;
    void Start()
    {
        AGAIN();
    }

    void AGAIN()
    {
        CheckCounter += 1;
        transform.Rotate(0, 90, 0, Space.Self);
        if (CheckCounter > 4)
            Destroy(this);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hitWall, .75f))
        {
            if (hitWall.transform.name == "Wall")
            {
                Destroy(this);
            }
            else
                AGAIN();
        }
        else
        {
            AGAIN();
        }
    }
}