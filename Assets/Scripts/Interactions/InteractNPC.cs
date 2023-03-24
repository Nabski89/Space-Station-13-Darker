using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractNPC : MonoBehaviour, IInteractable
{
    public Transform player;
    public string[] Chatter;
    [field: SerializeField] public float InteractionTime { get; private set; }
    public TMPro.TextMeshPro Display;
    void Start()
    {
        Display = GetComponentInChildren<TMPro.TextMeshPro>();
    }
    public void Interact(Interact source, CharController Character)
    {
        Character.busy = false;
        Display.text = Chatter[Random.Range(0, Chatter.Length)];
        timer = 5;
    }
    float timer = 5;
    void Update()
    {
        if (player != null)
        {
            transform.LookAt(new Vector3(player.position.x, 0, player.position.z));
        }
        if (Display.text != null)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Display.text = null;
                timer = 5;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        AggroController Player = other.GetComponent<AggroController>();
        if (Player != null)
        {
            player = Player.transform;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        AggroController Player = other.GetComponent<AggroController>();
        if (Player != null)
        {
            player = null;
        }
    }
}
