using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldown : MonoBehaviour
{
    Image CooldownBar;
    public CharController Character;

    Color32 GoGreen = new Color32(0, 132, 34, 255);
    Color32 NotRedy = new Color32(132, 0, 34, 255);
    void Start()
    {
        CooldownBar = GetComponent<Image>();
    }
    void Update()
    {
        CooldownBar.fillAmount = 1 - ((Character.AbilityCooldownCountdown) / Character.AbilityCooldown);
        if (Character.AbilityCooldownCountdown < 0)
            CooldownBar.GetComponent<Image>().color = GoGreen;
    }

    public void UseAbility()
    {
        //this is currently broken
        CooldownBar.GetComponent<Image>().color = NotRedy;
    }
}
