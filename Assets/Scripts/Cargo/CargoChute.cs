using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoChute : MonoBehaviour
{
    public float TravelDelay;
    public Vector3 EndLocation;
    public GameObject ScreenBlackoutUIElement;
    public GameObject CLANG;
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
        GameCrate Crate = other.GetComponent<CargoCrate>();
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
        Instantiate(CLANG, new Vector3(-200, 1, -200), transform.rotation, MainCharacter.transform);
        Invoke("PlayerLand", 10f);
    }
    void PlayerLand()
    {
        ScreenBlackoutUIElement.SetActive(false);
        MainCharacter.transform.position = EndLocation;
    }
    void ScoreCrate(GameObject Crate)
    {

        Crate.GetComponent<GameCrate>().CheckCrate();
        Instantiate(CLANG, transform.position, transform.rotation);
        Destroy(Crate);
    }
}
