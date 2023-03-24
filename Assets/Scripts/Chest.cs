using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject FirstBone;
    public GameObject SecondBone;
    float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        speed += Time.deltaTime;
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
