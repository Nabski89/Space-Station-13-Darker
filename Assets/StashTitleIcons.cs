using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StashTitleIcons : MonoBehaviour
{
    public int stashIndex; // Set this to the index you want to display
    public Image image; // Set this to the UI image component you want to set

    // Start is called before the first frame update
    void Start()
    {
        // Check if the stash array is long enough to hold the desired index
        if (StashCarryOver.StashedItem.Length > stashIndex)
        {
            image = GetComponent<Image>();
            if (StashCarryOver.StashedItem[stashIndex] != null)
            {
                Item item = StashCarryOver.StashedItem[stashIndex].GetComponent<Item>();
                Debug.Log("Stash Slot " + stashIndex + " contains" + item);
                image.color = new Color32(255, 255, 255, 255);
                image.sprite = item.Icon;
            }
            else
            {
                Debug.Log("Stash Slot " + stashIndex + " is empty");
                image.color = new Color32(0, 0, 0, 0);
            }
        }
        else
        {
            // Disable the parent GameObject if the stash array is too short
            transform.parent.gameObject.SetActive(false);
        }
    }


    void SetItToClear()
    {
    }
}
