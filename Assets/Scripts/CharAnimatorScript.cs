using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimatorScript : MonoBehaviour
{
    // Start is called before the first frame update
    Animator mAnimator;
    bool moving = false;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }
    /*
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
    */
    public void Attack()
    {
        Item WeaponHeld = GetComponentInChildren<Item>();
        if (WeaponHeld != null)
        {
            if (WeaponHeld.WeaponType == 0)
                mAnimator.SetTrigger("AxeAttack");
            if (WeaponHeld.WeaponType == 1)
                mAnimator.SetTrigger("DaggerAttack");
            if (WeaponHeld.WeaponType == 2)
                mAnimator.SetTrigger("SwordAttack");
        }
                else
            mAnimator.SetTrigger("AxeAttack");
            
        moving = false;
    }
}
