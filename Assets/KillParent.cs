using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillParent : MonoBehaviour
{

    void Start()
    {
        if (transform.parent != null)
        {
        GameObject WhosYourDaddy = transform.parent.gameObject;
        transform.parent = null;
        Destroy(WhosYourDaddy);
        }
    }

}
