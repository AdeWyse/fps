using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlants : Interactable
{
    public ParticleSystem[] showers;
    // Start is called before the first frame update
    void Start()
    {
        GameObject shower = GameObject.Find("Plants");
        if(shower != null )
        {
            showers = shower.GetComponentsInChildren<ParticleSystem>();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        base.Interact();
        foreach(ParticleSystem shower in showers)
        {
            shower.Play();
        }
    }
}
