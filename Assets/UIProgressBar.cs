using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProgressBar : MonoBehaviour
{

    Image Bar;
    public Interact Character;
    void Start()
    {
        Bar = GetComponent<Image>();
    }
    void Update()
    {
        Bar.fillAmount = Character.ActionTime / (Character.TimeReq);
    }
}
