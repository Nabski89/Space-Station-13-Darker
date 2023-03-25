using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemTank : MonoBehaviour
{
    public GameObject[] Pills;

    public bool[] ChemFilling;
    public float[] ChemLevels;
    public RectTransform[] ChemLevelsUI;
    public int RecipeAttempt = 0;
    public float InteractionTime;
    public static int[] Recipe;
    float TotalChems = 0;


    //this code needs some commenting
    //At the start we get three random forumlas and make sure they aren't the same
    //from each dispensor we are checking toggling a fill action or not
    //then at the end we check to see if we made it in the right order
    void Awake()
    {
        Recipe = new int[6];
        int i = 0;
        while (i < Recipe.Length)
        {
            int Digit2 = 0;
            int Digit3 = 0;
            while (i == Digit2 || i == Digit3 || Digit2 == Digit3)
            {
                Digit2 = Random.Range(0, ChemLevels.Length);
                Digit3 = Random.Range(0, ChemLevels.Length);
                Recipe[i] = i * 100 + Digit2 * 10 + Digit3 + 111;
            }
            i += 1;
        }
    }
    void Update()
    {
        int i = 0;
        while (i < ChemLevels.Length)
        {
            if (ChemFilling[i] == true)
            {
                ChemLevels[i] += Time.deltaTime;
                TotalChems += Time.deltaTime;
            }
            if (i != 0)
                ChemLevelsUI[i].localScale = new Vector3(1, Mathf.Max(ChemLevels[i], 0.0001f) / Mathf.Max(ChemLevels[i - 1], 0.0001f), 1);
            else
                ChemLevelsUI[i].localScale = new Vector3(1, Mathf.Max(ChemLevels[i], 0.0001f), 1);
            //do some scaling shit for a UI
            i += 1;
        }
        if (TotalChems > 10)
            Stop();
    }

    public void Add(int ChemicalNumber)
    {
        if (ChemFilling[ChemicalNumber] == false)
        {
            ChemFilling[ChemicalNumber] = true;
            RecipeAttempt = RecipeAttempt * 10 + (ChemicalNumber + 1);
        }
        else
            ChemFilling[ChemicalNumber] = false;
    }
    void Stop()
    {
        TotalChems = 0;
        int purity = 0;
        int i = 0;
        while (i < ChemLevels.Length)
        {
            ChemFilling[i] = false;
            if (ChemLevels[i] > 3)
                purity += 1;
            ChemLevels[i] = 0;
            i += 1;
        }
        if (RecipeAttempt > 100)
        {
            int j = 0;
            while (j < Recipe.Length)
            {
                if (Recipe[j] == RecipeAttempt)
                {
                    Instantiate(Pills[j], transform.position, transform.rotation);
                    Debug.Log("Made a " + Pills[j] + "Pill with purity: " + purity);
                }
                j += 1;
                if (j == Recipe.Length)
                    RecipeAttempt = 0;
            }
            Debug.Log("Failed to make a pill");
        }
        else
            Debug.Log("Failed to make a pill");
    }
}