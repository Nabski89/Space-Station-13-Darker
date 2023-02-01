using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterAbility : MonoBehaviour
{

    public int Ability;

    public void SelectAbility()
    {
        CharacterSelection.CharacterAbility = Ability;
                Debug.Log("Set Ability to " + Ability);
    }
}
