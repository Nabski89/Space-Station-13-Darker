using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoDisplayScreen : MonoBehaviour
{
    public TMPro.TextMeshPro Display;
    public CargoShuttle Shuttle;
    // Start is called before the first frame update
    void Start()
    {
        Display = GetComponent<TMPro.TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        Display.text = "ETA\n" + Mathf.FloorToInt(Shuttle.timer / 60).ToString() + ":" + Mathf.FloorToInt(Shuttle.timer % 60).ToString();
    }
}
