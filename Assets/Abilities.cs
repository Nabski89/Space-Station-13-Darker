using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public int ActiveAbility;
    public float[] AbilityCooldown;
    CharController CController;
    CharStats Stats;
    // Start is called before the first frame update
    void Start()
    {
        ActiveAbility = CharacterSelection.CharacterAbility;
        CController = GetComponentInParent<CharController>();
        Stats = GetComponentInParent<CharStats>();
    }

    // Update is called once per frame
    public void UseAbility()
    {
        Debug.Log("Used An Ability");
        if (ActiveAbility == 0)
            Ability0();
        if (ActiveAbility == 1)
            Ability1();
        if (ActiveAbility == 2)
            Ability2();
        if (ActiveAbility == 3)
            Ability3();
        if (ActiveAbility == 4)
            Ability4();
        if (ActiveAbility == 5)
            Ability5();
        if (ActiveAbility == 6)
            Ability6();
        if (ActiveAbility == 7)
            Ability7();

    }
    void Ability0()
    {
        Stats.Heal(Stats.HPMax / 4);
        CController.AbilityCooldown = AbilityCooldown[0];
    }
    void Ability1()
    {
        Stats.HealOT += 30;
        CController.AbilityCooldown = AbilityCooldown[1];
    }
    void Ability2()
    {
        Stats.CharDamageMod += .15f;
        CController.AbilityCooldown = AbilityCooldown[2];
        Invoke("Ability2Revoke", 10f);
    }
    void Ability2Revoke()
    {
        Stats.CharDamageMod -= .15f;
    }
    void Ability3()
    {
        Stats.CharDamageModTemp = 1.50f;
        CController.AbilityCooldown = AbilityCooldown[3];
    }
    void Ability4()
    {
        CController.playerSpeed += CController.playerSpeed;
        CController.AbilityCooldown = AbilityCooldown[4];
        Invoke("Ability4Revoke", 3f);
    }
    void Ability4Revoke()
    {
        CController.playerSpeed -= CController.playerSpeed / 2;
    }
    void Ability5()
    {
        CController.AbilityCooldown = AbilityCooldown[5];
    }
    void Ability6()
    {
        CController.AbilityCooldown = AbilityCooldown[6];
    }
    void Ability7()
    {
        CController.AbilityCooldown = AbilityCooldown[7];
    }
    void Ability8()
    {
        CController.AbilityCooldown = AbilityCooldown[8];
    }
}
