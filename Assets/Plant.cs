using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour, IInteractable
{
    public GameObject Seeds;
    public GameObject Crop;

    NeedsItem SeedHolder;
    // Update is called once per frame
    void Start()
    {
        SeedHolder = GetComponentInParent<NeedsItem>();
        SeedHolder.enabled = false;
        //    GetComponent<Renderer>().material.SetColor("APC Blue 3", Color.red);
    }


    public void Interact(Interact source, CharController Character)
    {
        Character.busy = false;
        Instantiate(Seeds, transform.position + transform.up + (0.5f * transform.right), transform.rotation);
        Instantiate(Crop, transform.position + transform.up - (0.5f * transform.right), transform.rotation);
        SeedHolder.enabled = true;
        Destroy(gameObject);
    }
}
