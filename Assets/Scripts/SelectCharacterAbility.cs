using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacterAbility : MonoBehaviour
{

    public int Ability;
    Image Icon;
    Color32 AbilityColor = new Color32(200, 150, 200, 255);
    // Start is called before the first frame update
    void Start()
    {
        Icon = GetComponent<Image>();
    }
    public void SelectAbility()
    {

        CharacterSelection.CharacterAbility = Ability;
        Debug.Log("Set Ability to " + Ability);
    }

    void Update()
    {
        if (CharacterSelection.CharacterAbility == Ability)
        {
            Icon.GetComponent<Image>().color = AbilityColor;
        }
        else
            Icon.GetComponent<Image>().color = Color.white;
    }
}
