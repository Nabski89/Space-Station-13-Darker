using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float Hunger = 0;
    public GameObject[] Face;
    int FaceNumber;
    // Start is called before the first frame update
    void Start()
    {
        FaceNumber = Random.Range(0, 6);
        Face[FaceNumber].SetActive(true);
    }

    // Update is called once per frame
    float facetime = 10;
    void Update()
    {
        //get a new face every 10 seconds
        facetime -= Time.deltaTime;
        if (facetime < 0)
        {
            Face[FaceNumber].SetActive(false);
            FaceNumber = Random.Range(0, 6);
            Face[FaceNumber].SetActive(true);
            facetime = 10;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Slime Touch");
        Item Item = other.GetComponent<Item>();
        if (Item != null)
        {
            Debug.Log("Slime Touch Item");
            if (Item.GetComponentInParent<Inventory>() == null)
            {
                Debug.Log("Slime EAT Item");
                Item.transform.parent = transform;

                Item.GetComponent<Rigidbody>().isKinematic = false;
                Item.Destroy(GetComponent<BoxCollider>());
                Item.gameObject.AddComponent<Digest>();
            }
        }
    }
}
