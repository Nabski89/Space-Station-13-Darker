using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
    public int ButtonPressed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //     agent.SetDestination(Vector3.zero);
        transform.position = Vector3.MoveTowards(transform.position, transform.parent.position + Vector3.up * (1+ButtonPressed*.25f), 1 * Time.deltaTime);

        if (transform.position == transform.parent.position + Vector3.up * (1+ButtonPressed*.25f))
        {
            this.enabled = false;
        }
    }
    public void Push()
    {
        if (ButtonPressed == 1)
            ButtonPressed = 0;
        else
            ButtonPressed = 1;
    }
}
