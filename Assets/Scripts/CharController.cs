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
        if (busy == false)
        {
            if (rb.velocity.x < Mathf.Abs(10))
                rb.AddForce(transform.forward * Input.GetAxis("Vertical") * playerSpeed);
            if (rb.velocity.z < Mathf.Abs(10))
                rb.AddForce(transform.right * Input.GetAxis("Horizontal") * playerSpeed);
        }
        //*1
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        //     float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(0, h, 0);

        if (AbilityCooldownCountdown > 0)
            AbilityCooldownCountdown -= Time.deltaTime;

//use an ability in the abilities script
        if (Input.GetKeyDown(KeyCode.Q) && AbilityCooldownCountdown <= 0)
        {
            Ability.UseAbility();
            AbilityCooldownCountdown = AbilityCooldown;
        }
    }
}
//*1
//https://stackoverflow.com/questions/26546664/how-to-rotate-the-player-when-moving-your-mouse