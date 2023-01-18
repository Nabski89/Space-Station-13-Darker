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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("EnemyAttackedPlayer");
        PlayerWeapon HitBy = other.GetComponent<PlayerWeapon>();
        if (HitBy != null)
        {
            HP -= 1;
            if (HitBy.OnHitSound != null)
            Instantiate(HitBy.OnHitSound, transform.position, transform.rotation);
            HitBy.enabled = false;
        }
    }
}
