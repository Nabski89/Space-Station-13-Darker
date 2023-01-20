using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        CharStats HPCheck = other.GetComponent<CharStats>();
        if (HPCheck != null)
        {
            Debug.Log(transform.name + " AttackedPlayer");
            HPCheck.HP -= 10;
            enabled = false;
        }
    }
}
