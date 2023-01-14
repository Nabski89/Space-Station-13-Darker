using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image WeightBar;
    public CharStats Character;
    void Start()
    {
        WeightBar = GetComponent<Image>();
    }
    void Update()
    {
        WeightBar.fillAmount = Character.HP / (Character.HPMax);
    }
}