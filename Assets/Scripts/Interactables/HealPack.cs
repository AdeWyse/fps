using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPack : Interactable
{
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        base.Interact();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        playerHealth.HealDamage(5);
        Destroy(gameObject);
    }
}
