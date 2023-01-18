using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(((Vector3.forward * 3)+Vector3.right*2+Vector3.up )* (Time.deltaTime));
    }
}
