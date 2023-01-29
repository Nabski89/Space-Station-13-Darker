using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
    public float HP = 2;
    public GameObject Loot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HP < 0)
        {
            Die();
        }
    }
    void Die()
    {
        Instantiate(Loot, transform.position, transform.rotation);
        Destroy(gameObject);
    }

//when the hitbox of a weapon hits something interesting, play a sound if able, and disable the hitbox so it doesn't double hit.
    private void OnTriggerEnter(Collider other)
    {
        PlayerWeapon HitBy = other.GetComponent<PlayerWeapon>();
        if (HitBy != null)
        {
            if (HitBy.enabled == true)
            {
                if (HitBy.OnHitSound != null)
                    Instantiate(HitBy.OnHitSound, transform.position, transform.rotation);
                HitBy.UpdateDamage();
                HP -= HitBy.DamageDealt;
                Debug.Log("EnemyAttacked " + transform + " new HP:" + HP);
                HitBy.enabled = false;
            }
        }
    }
}
