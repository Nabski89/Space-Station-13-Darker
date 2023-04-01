using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentDollManager : MonoBehaviour
{
    public Image[] SlotIcon;
    public bool isScaled = false;
    private Vector3 targetScale = new Vector3(0.25f, 0.25f, 0.25f);
    private float transitionSpeed = 5f;

    UIStats StatUI;
    void Start()
    {
        StatUI = GetComponentInChildren<UIStats>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isScaled)
            {
                targetScale = new Vector3(0.25f, 0.25f, 0.25f);
                isScaled = false;
            }
            else
            {
                targetScale = new Vector3(1.0f, 1.0f, 1.0f);
                isScaled = true;
            }
        }

        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * transitionSpeed);
    }

    public void EquipDollItem(int Slot, GameObject equipment)
    {
        SlotIcon[Slot].color = Color.white;
        SlotIcon[Slot].sprite = equipment. GetComponent<Equipment>().Icon;
    }
}