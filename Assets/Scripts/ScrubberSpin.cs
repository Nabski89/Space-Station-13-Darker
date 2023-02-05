using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrubberSpin : MonoBehaviour
{
    //I just wanna see that fans spin
    void Update()
    {
        transform.Rotate(new Vector3(0, 2, 0)); //applying rotation
    }
}
