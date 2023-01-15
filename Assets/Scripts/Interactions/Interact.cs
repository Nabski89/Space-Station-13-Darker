using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    IInteractable InteractObject;
    bool KeyDownEvent = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Keydown outside of update can miss calls
    void Update()
    {
        if (Input.GetKeyDown("f"))
            KeyDownEvent = true;
    }

    void FixedUpdate()
    {
        if (KeyDownEvent == true)
        {
            KeyDownEvent = false;
            Debug.Log("Pressed the interact Button");
            //clear these out before we cast so we can't pick things back up
            InteractObject = null;
            RaycastHit hitInteract;

            // Does the ray intersect any objects excluding the player layer
            //     Debug.DrawLine(transform.position, transform.position + (transform.forward * 2), Color.white, 10.0f);

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInteract, 2))
            {
                Debug.Log("Hit Something " + hitInteract.transform);
                Debug.DrawRay(transform.position, (transform.forward * 1 * hitInteract.distance), Color.yellow, 10f);
                InteractObject = hitInteract.transform.GetComponent<IInteractable>();
                if (InteractObject != null)
                {
                    Debug.Log("Did Hit the interactable " + hitInteract.transform);
                    InteractObject.Interact(this);
                }
            }
            else
            {
                //   Debug.DrawRay(transform.position, (transform.forward * 2), Color.green, 10f);
                Debug.Log("Did not Hit an interactable");
            }

        }
    }
}
