using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    NavMeshAgent agent;
    Animator mAnimator;
    bool ForgetPlayer = false;
    float ForgetPlayerTimer = 10;
    public float ForgetPlayerTimerDefault = 10;
    float AttackCycles;
    public float AttackCycleDefault = 3;
    float CycleTimer;
    float CycleTimerDefault = 2;
    public GameObject Weapon;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponentInParent<NavMeshAgent>();
        mAnimator = GetComponent<Animator>();

        //     agent.SetDestination(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {


        // if we have a velocity start to move the characters leg
        if (mAnimator != null)
        {
            if (agent.velocity.magnitude > 0)
                mAnimator.SetBool("Moving", true);
            else
                mAnimator.SetBool("Moving", false);
        }
        //if we have a target go after them
        if (player != null)
        {
            transform.LookAt(new Vector3(player.position.x, 0, player.position.z));
            agent.SetDestination(player.transform.position - (transform.forward * 1.5f));

            //attack cycling
            CycleTimer -= 1 * Time.deltaTime;
            if (CycleTimer < 0)
            {

                CycleTimer = CycleTimerDefault;
                AttackCycles -= 1;
                if (AttackCycles == 0)
                {
                    Attack();
                }
                if (AttackCycles == 1)
                {
                    if (mAnimator != null)
                        mAnimator.SetTrigger("Idle");
                }
            }
            //forgetting about the player when they are out of range
            if (ForgetPlayer == true)
            {
                ForgetPlayerTimer -= 1 * Time.deltaTime;
                if (ForgetPlayerTimer < 0)
                {
                    player = null;
                    ForgetPlayerTimer = ForgetPlayerTimerDefault;
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
            AttackCycles = 2;
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
        AttackCycles = AttackCycleDefault;
        Invoke("Disarm", 1.0f);
        Weapon.SetActive(true);
        if (mAnimator != null)
            mAnimator.SetTrigger("AxeAttack");
    }
    void Disarm()
    {
        Weapon.SetActive(false);
    }
}
