using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimatorScript : MonoBehaviour
{
    // Start is called before the first frame update
    Animator mAnimator;
    Rigidbody rb;
    bool moving = false;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody>();
        mAnimator.SetTrigger("AxeAttack");
    }
    void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y) < .01)
        {
            if (moving == true)
                StopMove();
        }
        else
        {
            if (moving == false)
                Walking();
        }

    }
    public void Walking()
    {
        mAnimator.SetTrigger("Moving");
        moving = true;
    }
    public void Grab()
    {
        mAnimator.SetTrigger("Grab");
    }
    public void Drop()
    {
        mAnimator.SetTrigger("Drop");
    }
    public void StopMove()
    {
        mAnimator.SetTrigger("StopMove");
        moving = false;
    }
        public void Attack()
    {
        mAnimator.SetTrigger("AxeAttack");
        moving = false;
    }
}
