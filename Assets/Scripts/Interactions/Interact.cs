using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    IInteractable InteractObject;
    bool KeyDownEvent = false;
    public GameObject UITextObj;
    public TMPro.TextMeshProUGUI UIText;
    CharController CharacterController;

    // Start is called before the first frame update
    void Start()
    {
        UIText = UITextObj.GetComponent<TMPro.TextMeshProUGUI>();
        CharacterController = gameObject.GetComponentInParent<CharController>();
    }

    // Keydown outside of update can miss calls
    void Update()
    {
        if (Input.GetKeyDown("f"))
            KeyDownEvent = true;
    }

    void FixedUpdate()
    {

        //clear these out before we cast so we can't pick things back up
        InteractObject = null;
        RaycastHit hitInteract;

        // Does the ray intersect any objects excluding the player layer
        //     Debug.DrawLine(transform.position, transform.position + (transform.forward * 2), Color.white, 10.0f);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInteract, 2))
        {
            //Debug.Log("Hit Something " + hitInteract.transform);
            //Debug.DrawRay(transform.position, (transform.forward * 1 * hitInteract.distance), Color.yellow, 10f);
            InteractObject = hitInteract.transform.GetComponent<IInteractable>();
            if (InteractObject != null)
            {
                UITextObj.SetActive(true);
                UIText.text = hitInteract.transform.name;
                //         Debug.Log("Did Hit the interactable " + hitInteract.transform);
                if (KeyDownEvent == true)
                {
                    KeyDownEvent = false;
                    CharacterController.busy = true;
                    Debug.Log("Pressed the interact Button");
                    InteractObject.Interact(this, CharacterController);
                }
            }
        }
        else
        {
            //   Debug.DrawRay(transform.position, (transform.forward * 2), Color.green, 10f);
            //     Debug.Log("Did not Hit an interactable");
            UITextObj.SetActive(false);
        }
        KeyDownEvent = false;
    }
}