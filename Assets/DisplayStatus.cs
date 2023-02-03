using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayStatus : MonoBehaviour
{
    public static float TIMER = 30;
    public static string CountdownDisplay;
    float ETA = 10 * 60;
    float DEPART = 3 * 60;
    public GameObject CalledSound;
    public GameObject DockSound;
    public GameObject Player;
    // Update is called once per frame
    void Update()
    {
        TIMER -= Time.deltaTime;
        CountdownDisplay = "ETA\n"+Mathf.FloorToInt(TIMER / 60).ToString() + ":" + Mathf.FloorToInt(TIMER % 60).ToString();
        if (TIMER < 0)
        {
            if (CalledSound != null)
            {
                Instantiate(CalledSound, Player.transform.position, Quaternion.identity);
                TIMER = ETA;
                CalledSound = null;
            }
            else
            {
                Instantiate(DockSound, Player.transform.position, Quaternion.identity);
                TIMER = DEPART;
                //this is how we end the round
            }
        }
    }
}
