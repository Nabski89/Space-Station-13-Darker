using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemistryRecipes : MonoBehaviour
{
    public static int CharacterAbility;
    public static Vector3 StartLocation = new Vector3(-4.0f, 0.0f, 1.0f);
    // Start is called before the first frame update
    void Start()
    {
        LoadCharacterUnlocks();
        LoadPerkUnlocks();
        LoadAbilityrUnlocks();

    }


    //determines if characters are unlocked, by default only the first one is. I should make that the assistant but for now it's still the virologist
    public static Dictionary<CharUnlockEnum, int> CharUnlockTracker = new Dictionary<CharUnlockEnum, int>();
    public enum CharUnlockEnum { Char1, Char2, Char3, Char4, Char5, Char6 };
    void LoadCharacterUnlocks()
    {
        CharUnlockTracker.Add(CharUnlockEnum.Char1, 1);
        CharUnlockTracker.Add(CharUnlockEnum.Char2, Random.Range(0, 2));
        CharUnlockTracker.Add(CharUnlockEnum.Char3, Random.Range(0, 2));
        CharUnlockTracker.Add(CharUnlockEnum.Char4, Random.Range(0, 2));
        CharUnlockTracker.Add(CharUnlockEnum.Char5, Random.Range(0, 2));
        CharUnlockTracker.Add(CharUnlockEnum.Char6, 0); //unlock by building a borg
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
