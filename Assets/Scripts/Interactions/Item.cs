using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [field: SerializeField] public float InteractionTime { get; private set; }
    public Sprite Icon;
    public int Quality = 0;
    Collider m_ObjectCollider;
    //This will be used to determine what attack type it falls under and assign it. Current max is three for 0Axe 1Dagger 2Sword
    public int WeaponType = 0;
    bool NoMoreUpgrades = false;

    void Start()
    {
        transform.name = transform.name.Replace("(Clone)", "").Trim();
        QualityUpgrade();
        m_ObjectCollider = GetComponent<Collider>();
        if (WeaponType > 3)
            WeaponType = 3;
    }
    public void Interact(Interact source, CharController Character)
    {
        Character.busy = false;
        var playerInventory = source.GetComponentInParent<Inventory>();

        m_ObjectCollider.isTrigger = true;
        Destroy(gameObject.GetComponent<Rigidbody>());

        playerInventory.TryPickup(this);
    }

    void QualityUpgrade()
    {
        if (Quality < 4 && NoMoreUpgrades == false)
        {
            if (Random.Range(0, 2) > 0)
            {
                Quality += 1;
                QualityUpgrade();
            }
            else
                NoMoreUpgrades = true;
        }
    }
}