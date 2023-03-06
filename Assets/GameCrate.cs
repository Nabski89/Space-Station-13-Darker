using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCrate : MonoBehaviour
{
    public string LabelOrderNumber;
    public string OrderNumber;
    public string LabelDepartmentName;
    public string TrueDepartmentName;
    public string[] DepartmentTypos;
    public string LabelContents;
    public bool ContentFail = false;
    public string[] PossibleContents;


    public TMPro.TextMeshPro Display;
    //set our correct versions, have a chance of being a fake crate, then override the correct one. After that pass that info down to the manifest.
    void Start()
    {
        OrderNumber = Random.Range(0, 10).ToString() + Random.Range(0, 10).ToString() + Random.Range(0, 10).ToString() + Random.Range(0, 10).ToString() + Random.Range(0, 10).ToString();
        if (Random.Range(0, 10) < 1)
        {
            int ReplaceNum = Random.Range(0, 5);
            LabelOrderNumber = OrderNumber.Substring(0, ReplaceNum) + Random.Range(0, 10).ToString() + OrderNumber.Substring(ReplaceNum + 1);

        }

        OrderNumber = LabelOrderNumber;

        LabelDepartmentName = TrueDepartmentName;
        if (Random.Range(0, 10) < 1)
            LabelDepartmentName = DepartmentTypos[Random.Range(0, DepartmentTypos.Length)];

        LabelContents = PossibleContents[Random.Range(0, PossibleContents.Length)];
        if (Random.Range(0, 10) < 1)
            ContentFail = true;


        Display = GetComponentInChildren<TMPro.TextMeshPro>();
        Display.text = "<br>Order #: " + LabelOrderNumber + "<br>Department: " + LabelDepartmentName + "<br>Contents: " + LabelContents;
    }
    void CheckCrate()
    {
        if (LabelOrderNumber == OrderNumber && LabelDepartmentName == TrueDepartmentName && ContentFail == false)
        {

        }
        //check if our order number, department type, contents, and such are all correct, probably by seeing if they are null
    }
}