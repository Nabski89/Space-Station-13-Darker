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
    public bool busy = false;
    public bool jump = false;
    public float AbilityCooldown = 10;
    public float AbilityCooldownCountdown = 10;
    public Abilities Ability;

    void Start()
    {
        //set the frame rate
        transform.position = CharacterSelection.StartLocation;
        Application.targetFrameRate = 30;
        rb = GetComponent<Rigidbody>();
        Ability = GetComponentInChildren<Abilities>();
    }

    void Update()
    {
        /* JUMP CODE THAT ISN"T WORKING
        if (busy == false)
        {
            if (Input.GetKeyDown("space") && rb.velocity.y == 0)
                jump = true;
        }
        */
        //*1
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        //     float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(0, h, 0);

        if (AbilityCooldownCountdown > 0)
            AbilityCooldownCountdown -= Time.deltaTime;

        //use an ability in the abilities script
        if (Input.GetKeyDown(KeyCode.Q) && AbilityCooldownCountdown <= 0)
        {
            AbilityCooldownCountdown = AbilityCooldown;
            Ability.UseAbility();

        }
    }

    void FixedUpdate()
    {
        if (busy == false)
        {
            if (rb.velocity.x < Mathf.Abs(10))
                rb.AddForce(transform.forward * Input.GetAxis("Vertical") * playerSpeed * 10);
            if (rb.velocity.z < Mathf.Abs(10))
                rb.AddForce(transform.right * Input.GetAxis("Horizontal") * playerSpeed * 10);
        }
        /*    if (jump == true)
            {
                rb.AddForce(transform.up * 2000);
                jump = false;
            }
            */
    }
}
//*1
//https://stackoverflow.com/questions/26546664/how-to-rotate-the-player-when-moving-your-mouse