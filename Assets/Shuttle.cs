using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuttle : MonoBehaviour
{
    public Vector3 StartLocation;
    public Vector3 DockLocation;
    public Vector3 EscapeLocation;
    public int ShuttleStage = 0;
    void Update()
    {
        if (ShuttleStage == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, DockLocation, 1 * Time.deltaTime);


            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, 1);


            if (transform.localScale.x < 0.98)
            {
                if (transform.localScale.x < 0.50)
                    transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
                transform.localScale += new Vector3(0.2f, 0.2f, 0.2f) * Time.deltaTime;

                if (transform.localScale.x > 0.98)
                    transform.localScale = Vector3.one;
            }
            if (transform.position == DockLocation)
                ShuttleStage = 0;
        }
        if (ShuttleStage == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, EscapeLocation, 1 * Time.deltaTime);
            if (transform.position == EscapeLocation)
                ShuttleStage = 0;
        }
    }
}
