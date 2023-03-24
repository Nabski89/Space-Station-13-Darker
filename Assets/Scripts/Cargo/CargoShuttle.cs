using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoShuttle : MonoBehaviour
{
    public GameObject[] Crates;
    public bool Called = false;
    public bool FromCentcomm = true;
    public float timer;
    public float Scale;
    public Vector3 StartLocation;
    public Vector3 DockLocation;

    //done from the cargo console
    public void CallSend()
    {
        if (Called == false)
        {
            Called = true;
            timer = 60;
        }
    }
    //once called, it warps in then docks
    void Update()
    {
        if (Called == true)
        {
            timer -= Time.deltaTime;
            if (timer < 5)
            {
                if (FromCentcomm == true)
                {
                    transform.position = DockLocation;
                    Scale += 0.04f * Time.deltaTime;
                }
                else
                    Scale -= 0.04f * Time.deltaTime;
                if (Random.Range(0, 1 - Scale) > 0.1f)
                    transform.localScale = Random.Range(0, 1) * Vector3.one;
                else
                    transform.localScale = Vector3.one * Scale;
                if (timer < 0)
                {
                    transform.localScale = Vector3.one;
                    Called = false;
                    Dock();
                }
            }
        }
    }
    //once docked it spawns crates if on the station, otherwise it shrinks and hides
    void Dock()
    {
        if (FromCentcomm == true)
        {
            Debug.Log("Cargo Shuttle has docked at the station");
            int CrateCount = Random.Range(2, 8);
            Debug.Log(CrateCount);
            while (CrateCount > 0)
            {
                Instantiate(Crates[Random.Range(0, Crates.Length)], transform.position + Vector3.right * (Random.Range(-3.5f, 0.5f)) + Vector3.forward * (Random.Range(-1.5f, 4.5f)), transform.rotation, transform);
                CrateCount -= 1; ;
            }
            Scale = 1;
            FromCentcomm = false;
        }
        else
        {
            transform.localScale = Vector3.one * 0.001f; ;
            Scale = 0.01f;
            transform.position = StartLocation;
            FromCentcomm = true;
        }
    }
}