using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAbility : MonoBehaviour
{
    public int AbilityNumber;

    void Awake()
    {
        Debug.Log("Example1.Awake() was called");
        if (CharacterSelection.CharacterAbility != AbilityNumber)
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
