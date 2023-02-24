using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorScript : MonoBehaviour
{
    Animator mAnimator;
    public Collider m_ObjectCollider;
    public Collider m_ObjectCollider2;
    NavMeshObstacle Blocker;
    bool IsOpenStatus = false;
    public GameObject OpenSoundEffect;
    public GameObject CloseSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        Blocker = GetComponent<NavMeshObstacle>();
        mAnimator = GetComponent<Animator>();
    }
    public void DoorInteract()
    {
        if (IsOpenStatus == false)
            Open();
        else
            Close();
    }
    // Update is called once per frame
    public void Open()
    {
        Debug.Log("Try To Open Door");
        mAnimator.SetTrigger("DoorOpen");
        IsOpenStatus = true;
        Blocker.enabled = false;
        m_ObjectCollider.isTrigger = true;
        m_ObjectCollider2.isTrigger = true;

        if (OpenSoundEffect != null)
        {
            GameObject OpenSE = Instantiate(OpenSoundEffect, transform);
            Destroy(OpenSE, 5);
        }
        Invoke("AutoClose", 20);
    }

    public void Close()
    {
        Debug.Log("Try To CLOSE Door");
        mAnimator.SetTrigger("DoorClose");
        IsOpenStatus = false;
        Blocker.enabled = true;
        m_ObjectCollider.isTrigger = false;
        m_ObjectCollider2.isTrigger = false;

        if (CloseSoundEffect != null)
        {
            GameObject CloseSE = Instantiate(CloseSoundEffect, transform);
            Destroy(CloseSE, 5);
        }
    }

    public void AutoClose()
    {
        if (IsOpenStatus == true)
            Close();
    }

}
