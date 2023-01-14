using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHead : MonoBehaviour
{
   float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float MouseY = Input.GetAxis("Mouse Y");

        xRotation -= MouseY*1.5f;
//        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(Mathf.Clamp(xRotation, -45f, 45f), 0f, 0f);
    }


}
