using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    Rigidbody rb;
    public float playerSpeed = 1.0f;
    //*1
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    public GameObject[] Hands;

    void Start()
    {
        //set the frame rate
        Application.targetFrameRate = 30;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb.velocity.x < Mathf.Abs(10))
            rb.AddForce(transform.forward * Input.GetAxis("Vertical") * playerSpeed);
        if (rb.velocity.z < Mathf.Abs(10))
            rb.AddForce(transform.right * Input.GetAxis("Horizontal") * playerSpeed);
        //*1
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        //     float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(0, h, 0);

        //swap to the active hand
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DisableHands();
            Hands[0].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DisableHands();
            Hands[1].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DisableHands();
            Hands[2].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DisableHands();
            Hands[3].SetActive(true);
        }
    }
    void FixedUpdate()
    {
    }

    void DisableHands()
    {
        Hands[0].SetActive(false);
        Hands[1].SetActive(false);
        Hands[2].SetActive(false);
        Hands[3].SetActive(false);
    }
}
//*1
//https://stackoverflow.com/questions/26546664/how-to-rotate-the-player-when-moving-your-mouse