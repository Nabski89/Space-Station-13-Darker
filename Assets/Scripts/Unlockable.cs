using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlockable : MonoBehaviour
{
    public CharacterSelection.CharUnlockEnum CharacterType;
    Image Icon;
    Color32 NotUnlockedColor = new Color32(10, 10, 10, 255);
    // Start is called before the first frame update
    void Start()
    {
        Icon = GetComponent<Image>();
        Icon.GetComponent<Image>().color = NotUnlockedColor;
    }

    // Update is called once per frame
    void Update()
    {
       if (CharacterSelection.CharUnlockTracker[CharacterType] > 0)
        {
            Icon.GetComponent<Image>().color = Color.white;
            Destroy(this);
        }
    }
}
