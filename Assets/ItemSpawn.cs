using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject[] SpawnList;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(SpawnList[Random.Range(0,SpawnList.Length)], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
