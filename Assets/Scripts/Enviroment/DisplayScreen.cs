using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScreen : MonoBehaviour
{
        public TMPro.TextMeshPro Display;
    // Start is called before the first frame update
    void Start()
    {
        Display = GetComponent<TMPro.TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        Display.text = DisplayStatus.CountdownDisplay;
    }
}
