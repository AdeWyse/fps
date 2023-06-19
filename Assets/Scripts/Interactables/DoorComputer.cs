using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorComputer : Interactable
{
    public  Animator anim;
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
        anim.SetBool("character_nearby", !(anim.GetBool("character_nearby")));
    }
}
