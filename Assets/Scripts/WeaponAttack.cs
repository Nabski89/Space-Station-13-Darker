using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public CharAnimatorScript AnimateReference;
    public bool WeaponReady = true;

    // Update is called once per frame

    void Start()
    {
        AnimateReference.Attack();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && WeaponReady == true)
        {
            //I hate that I have had to copy this code directly off the turtorial but I'm unafan of getting all these nulls

            PlayerWeapon WeaponHitbox = GetComponentInChildren(typeof(PlayerWeapon)) as PlayerWeapon;

            if (WeaponHitbox != null)
            {
                WeaponHitbox.enabled = true;
            }
            WeaponReady = false;
            Invoke("AttackReady", 2);
            Debug.Log("We Attacked");
            AnimateReference.Attack();
        }
    }

    void AttackReady()
    {
        WeaponReady = true;
    }
}
