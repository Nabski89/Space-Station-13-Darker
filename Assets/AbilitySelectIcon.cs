using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySelectIcon : MonoBehaviour
{
    public Sprite[] AbilityPicture;
    // Start is called before the first frame update
    void Start()
    {
        Image m_Image = GetComponent<Image>();

        m_Image.sprite = AbilityPicture[CharacterSelection.CharacterAbility];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
