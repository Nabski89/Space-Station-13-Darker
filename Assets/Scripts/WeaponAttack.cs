using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public CharAnimatorScript AnimateReference;

    // Update is called once per frame

    void Start()
    {
        AnimateReference.Attack();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //I hate that I have had to copy this code directly off the turtorial but I'm unafan of getting all these nulls

            /*  PlayerWeapon WeaponHitbox = GetComponentInChildren(typeof(PlayerWeapon)) as PlayerWeapon;

              if (WeaponHitbox != null)
              {
                  WeaponHitbox.enabled = true;
              }
              */
            AnimateReference.Attack();
            Debug.Log("We Attacked");
        }
    }
}
