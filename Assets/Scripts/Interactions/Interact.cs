using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    IInteractable InteractObject;
    IInteractable InteractObjectActioning;
    bool KeyDownEvent = false;
    public GameObject UITextObj;
    public TMPro.TextMeshProUGUI UIText;
    CharController CharacterController;
    public float ActionTime = 0;
    public float TimeReq = 0.5f;
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
        {
            if (CharacterController.busy != true)
                KeyDownEvent = true;
            else
            {
                if (InteractObjectActioning != null)
                    InteractObjectActioning = null;
                CharacterController.busy = false;
                ActionTime = InteractObjectActioning.InteractionTime;
            }
        }

        if (CharacterController.busy == true)
        {
            ActionTime += Time.deltaTime;
            if (ActionTime > TimeReq)
            {
                InteractObjectActioning.Interact(this, CharacterController);
                InteractObjectActioning = null;
                CharacterController.busy = false;
                ActionTime = 0;
            }
        }
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

                Item InteractItem = hitInteract.transform.GetComponent<Item>();
                if (InteractItem != null)
                    TextColor(InteractItem.Quality);
                else
                    UIText.color = Color.white;
                //         Debug.Log("Did Hit the interactable " + hitInteract.transform);
                if (KeyDownEvent == true)
                {
                    KeyDownEvent = false;
                    CharacterController.busy = true;
                    Debug.Log("Pressed the interact Button");
                    InteractObjectActioning = InteractObject;
                }
            }
            else
                UITextObj.SetActive(false);
        }
        else
        {
            //   Debug.DrawRay(transform.position, (transform.forward * 2), Color.green, 10f);
            //     Debug.Log("Did not Hit an interactable");
            UITextObj.SetActive(false);
        }
        KeyDownEvent = false;
    }
    void TextColor(int Number)
    {
        switch (Number)
        {
            case 0:
                UIText.color = Color.gray;
                break;
            case 1:
                UIText.color = Color.white;
                break;
            case 2:
                UIText.color = Color.green;
                break;
            case 3:
                UIText.color = new Color(0, 0.44f, 0.87f, 1.0f);
                break;
            case 4:
                UIText.color = new Color(0.64f, 0.21f, 0.93f, 1.0f);
                break;
        }
    }
}