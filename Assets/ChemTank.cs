using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemTank : MonoBehaviour
{
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;

    public bool[] ChemFilling;
    public float[] ChemLevels;
    public RectTransform[] ChemLevelsUI;
    public int RecipeAttempt = 0;
    public int Recipe1 = 0;
    public int Recipe2 = 0;
    public int Recipe3 = 0;
    float TotalChems = 0;


    //this code needs some commenting
    //At the start we get three random forumlas and make sure they aren't the same
    //from each dispensor we are checking toggling a fill action or not
    //then at the end we check to see if we made it in the right order
    void Start()
    {
        Recipe1 = Random.Range(0, ChemLevels.Length) * 100 + Random.Range(0, ChemLevels.Length) * 10 + Random.Range(0, ChemLevels.Length) + 111;
        Recipe2 = Random.Range(0, ChemLevels.Length) * 100 + Random.Range(0, ChemLevels.Length) * 10 + Random.Range(0, ChemLevels.Length) + 111;
        Recipe3 = Random.Range(0, ChemLevels.Length) * 100 + Random.Range(0, ChemLevels.Length) * 10 + Random.Range(0, ChemLevels.Length) + 111;
        while (Recipe2 == Recipe1)
            Recipe2 = Random.Range(0, ChemLevels.Length) * 100 + Random.Range(0, ChemLevels.Length) * 10 + Random.Range(0, ChemLevels.Length) + 111;
        while (Recipe3 == Recipe2 || Recipe3 == Recipe1)
            Recipe3 = Random.Range(0, ChemLevels.Length) * 100 + Random.Range(0, ChemLevels.Length) * 10 + Random.Range(0, ChemLevels.Length) + 111;

    }
    void Update()
    {
        int i = 0;
        while (i < ChemLevels.Length)
        {
            if (ChemFilling[i] == true)
                ChemLevels[i] += Time.deltaTime;
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
            if (RecipeAttempt > 10)
                RecipeAttempt += (ChemicalNumber * 100) + 1;
            if (RecipeAttempt > 0)
                RecipeAttempt += (ChemicalNumber * 10) + 1;
            if (RecipeAttempt == 0)
                RecipeAttempt = ChemicalNumber + 1;
        }
        else
            ChemFilling[ChemicalNumber] = false;
    }
    void Stop()
    {
        int i = 0;
        while (i < ChemLevels.Length)
        {
            ChemFilling[i] = false;
        }
    }
}
