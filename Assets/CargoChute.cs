using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoChute : MonoBehaviour
{
    public float TravelDelay;
    public Vector3 EndLocation;
    public GameObject ScreenBlackoutUIElement;
    GameObject MainCharacter;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        CharController Player = other.GetComponent<CharController>();
        if (Player != null)
        {
            MainCharacter = Player.gameObject;
            PlayerTravel();
        }
        /*
        CargoCrate Crate = other.GetComponent<CargoCrate>();
                if (Crate != null)
        {
            ScoreCrate(Crate);
        }
        */
    }
    void PlayerTravel()
    {
        ScreenBlackoutUIElement.SetActive(true);
        MainCharacter.transform.position = new Vector3(-200, 1, -200);
        Invoke("PlayerLand", 10f);
    }
    void PlayerLand()
    {
        ScreenBlackoutUIElement.SetActive(false);
        MainCharacter.transform.position = EndLocation;
    }
    void ScoreCrate(GameObject Crate)
    {

    }
}
