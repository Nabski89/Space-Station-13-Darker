using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject OnHitSound;
    public float DamageModifier;
    public float OriginalDamage;
    public float DamageDealt;
    // Start is called before the first frame update
    public void UpdateDamage()
    {
        CharStats Character = GetComponentInParent<CharStats>();
        if (Character != null)
        {
            DamageDealt = OriginalDamage * Character.CharDamageMod * Character.CharDamageModTemp;
            Character.CharDamageModTemp = 1;
        }
    }
}
