using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject[] SpawnList;
    public float SpawnChance = 100;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 100) < SpawnChance)
        {
            GameObject LootSpawned = Instantiate(SpawnList[Random.Range(0, SpawnList.Length)], transform.position, transform.rotation);
            if (transform.parent != null)
                LootSpawned.transform.parent = transform.transform;
            //add something about the loot quality here
            //get component the script we want
            //if not null
            //then upgrade quality
            //maybe with a while loop and it's 50/50 odds each time?
            //turns out I put this on the object itself
        }
        Destroy(gameObject, 2);
    }
}
