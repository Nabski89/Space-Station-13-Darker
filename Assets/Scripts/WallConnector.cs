using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallConnector : MonoBehaviour
{
    // Raycast and go looking for a wall. If we hit one then keep it around otherwise destroy the connector.
    void Start()
    {
        RaycastHit hitWall;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitWall, .75f))
        {
            Debug.Log("Wall Test Something " + hitWall.transform.name);
            if (hitWall.transform.name == "Wall")
                Destroy(this);
            else
                Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
