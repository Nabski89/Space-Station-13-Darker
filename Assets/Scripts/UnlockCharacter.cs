using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCharacter : MonoBehaviour
{
    public CharacterSelection.CharUnlockEnum CharacterType;
    // Start is called before the first frame update
    void Start()
    {
        CharacterSelection.CharUnlockTracker[CharacterType] += 1;
        Destroy(this);
    }
}
