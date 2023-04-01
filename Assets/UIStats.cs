using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStats : MonoBehaviour
{
    public CharStats charStats;
    EquipmentDollManager ParentUI;
    public TMPro.TextMeshProUGUI textMesh;
    private Vector3 targetScale;
    private bool Scaled = false;

    void Start()
    {
        ParentUI = GetComponentInParent<EquipmentDollManager>();
        textMesh = GetComponent<TMPro.TextMeshProUGUI>();
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (Scaled == true)
            {
                Minimize();
            }
            else
            {
                Maximize();
            }
        }
        if (Scaled == true)
        {
            if (ParentUI.isScaled == true)
            {
                // Display the four values in the TextMeshPro object
                textMesh.text = "Strength: " + charStats.Strength + "\n"
                               + "Agility: " + charStats.Agility + "\n"
                               + "Knowledge: " + charStats.Knowledge + "\n"
                               + "Resourcefulness: " + charStats.Resourcefulness
                               + "Move Speed" + "\n"
                               + "Attack Speed" + "\n"
                               + "Attack Damage" + "\n"
                               + "Space Protection"
                               ;
            }
            else
                textMesh.text = " ";
        }
    }
    public void Minimize()
    {
        targetScale = new Vector3(1f, 0, 1f);
        Scaled = false;
        textMesh.text = " ";
    }
    public void Maximize()
    {
        targetScale = new Vector3(1.0f, 1.0f, 1.0f);
        Scaled = true;
    }
}