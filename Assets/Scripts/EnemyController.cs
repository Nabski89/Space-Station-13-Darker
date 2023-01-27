using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player;
    NavMeshAgent agent;
    bool ForgetPlayer = false;
    float ForgetPlayerTimer = 10;

    float AttackCycles;
    float AttackCycleDefault;
    float CycleTimer;
    float CycleTimerDefault;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //     agent.SetDestination(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        //if we have a target go after them
        if (player != null)
        {
            transform.LookAt(new Vector3(player.position.x, 0, player.position.z));
            agent.SetDestination(player.transform.position);


            //attack cycling
            CycleTimer -= 1 * Time.deltaTime;
            if (CycleTimer < 0)
            {
                CycleTimer = CycleTimerDefault;
                AttackCycles -= 1;
                if (AttackCycles < 0)
                {
                    Attack();
                }
            }
            //forgetting about the player when they are out of range
            if (ForgetPlayer == true)
            {
                ForgetPlayerTimer -= 1 * Time.deltaTime;
                if (ForgetPlayerTimer < 0)
                {
                    player = null;
                    ForgetPlayerTimer = 10;
                    agent.ResetPath();
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        AggroController Player = other.GetComponent<AggroController>();
        if (Player != null)
        {
            player = Player.transform;
            ForgetPlayer = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        AggroController Player = other.GetComponent<AggroController>();
        if (Player != null)
        {
            ForgetPlayer = true;
        }
    }

    void Attack()
    {

    }
}
