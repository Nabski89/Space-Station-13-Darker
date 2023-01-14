using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Vector3.zero);

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player);
            agent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        AggroController Player = other.GetComponent<AggroController>();
        if (Player != null)
        {
            player = Player.transform;
        }
    }
}
