using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
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
        CharUnlockTracker.Add(CharUnlockEnum.Char6, Random.Range(0, 2));
    }

    public static Dictionary<PerkUnlockEnum, int> PerkUnlockTracker = new Dictionary<PerkUnlockEnum, int>();
    public enum PerkUnlockEnum { Perk1, Perk2, Perk3, Perk4, Perk5, Perk6 };
    void LoadPerkUnlocks()
    {
        PerkUnlockTracker.Add(PerkUnlockEnum.Perk1, 1);
        PerkUnlockTracker.Add(PerkUnlockEnum.Perk2, Random.Range(0, 2));
        PerkUnlockTracker.Add(PerkUnlockEnum.Perk3, Random.Range(0, 2));
        PerkUnlockTracker.Add(PerkUnlockEnum.Perk4, Random.Range(0, 2));
        PerkUnlockTracker.Add(PerkUnlockEnum.Perk5, Random.Range(0, 2));
        PerkUnlockTracker.Add(PerkUnlockEnum.Perk6, Random.Range(0, 2));
    }

    public static Dictionary<AbilityUnlockEnum, int> AbilityUnlockTracker = new Dictionary<AbilityUnlockEnum, int>();
    public enum AbilityUnlockEnum { Ability1, Ability2, Ability3, Ability4, Ability5, Ability6 };
    void LoadAbilityrUnlocks()
    {
        AbilityUnlockTracker.Add(AbilityUnlockEnum.Ability1, 1);
        AbilityUnlockTracker.Add(AbilityUnlockEnum.Ability2, Random.Range(0, 2));
        AbilityUnlockTracker.Add(AbilityUnlockEnum.Ability3, Random.Range(0, 2));
        AbilityUnlockTracker.Add(AbilityUnlockEnum.Ability4, Random.Range(0, 2));
        AbilityUnlockTracker.Add(AbilityUnlockEnum.Ability5, Random.Range(0, 2));
        AbilityUnlockTracker.Add(AbilityUnlockEnum.Ability6, Random.Range(0, 2));
    }
}
