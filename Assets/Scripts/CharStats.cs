using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharStats : MonoBehaviour
{
    public float HPMax = 100;
    public float HP = 50;
    public float HealOT = 5;
    float HealingMod;
    float HealOTMod;
    public float CharDamageMod = 1.00f;
    public float CharDamageModTemp = 1.00f;
    bool DEAD = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //delayed healing effects
        if (HealOT > 0)
        {
            HP = Mathf.Min(HP + (HealOT * Time.deltaTime), HPMax);
            HealOT -= Time.deltaTime;
        }
        //death tracking
        if (HP < 0)
        {
            Quaternion target = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 45);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 1);

            DEAD = true;
            Invoke("YouDiedAutoResetart", 30);
            GetComponent<CharController>().enabled = false;
            GetComponentInChildren<MoveHead>().enabled = false;
        }
        if (DEAD == true)
        {
            if (Input.GetMouseButtonDown(0))
                SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
        }

    }
    void YouDiedAutoResetart()
    {
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
    }
    public void Heal(float HealAmount)
    {
        HP = Mathf.Min(HP + (HealAmount) + HealingMod, HPMax);
    }
}
