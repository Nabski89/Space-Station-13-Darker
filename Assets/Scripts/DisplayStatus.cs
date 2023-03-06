using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayStatus : MonoBehaviour
{
    public static float TIMER = 30;
    public static string CountdownDisplay;
    public Shuttle EvacShuttle;
    float ETA = 15;
    //10 * 60;
    float DEPART = 15;
    //3 * 60;
    float ENDROUND = 30;
    public int ShuttleStatus = 0;

    public GameObject CalledSound;
    public GameObject DockSound;
    public GameObject Player;
    // Update is called once per frame
    void Update()
    {
        TIMER -= Time.deltaTime;
        CountdownDisplay = "ETA\n" + Mathf.FloorToInt(TIMER / 60).ToString() + ":" + Mathf.FloorToInt(TIMER % 60).ToString();
        if (TIMER < 0)
            switch (ShuttleStatus)
            {
                case 0:
                    Instantiate(CalledSound, Player.transform.position, Quaternion.identity);
                    TIMER = ETA;
                    ShuttleStatus = 1;
                    EvacShuttle.ShuttleStage = 1;
                    break;
                case 1:
                    Instantiate(DockSound, Player.transform.position, Quaternion.identity);
                    TIMER = DEPART;
                    EvacShuttle.ShuttleStage = 2;
                    ShuttleStatus = 2;
                    DockSound = null;
                    break;
                case 2:
                    Instantiate(DockSound, Player.transform.position, Quaternion.identity);
                    TIMER = ENDROUND;
                    //this is how we end the round
                    break;
            }
    }
}
