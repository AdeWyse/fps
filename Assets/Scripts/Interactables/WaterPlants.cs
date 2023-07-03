using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlants : Interactable
{
    public ParticleSystem[] showers;
    public AudioSource[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        GameObject shower = GameObject.Find("Plants");
        if(shower != null )
        {
            showers = shower.GetComponentsInChildren<ParticleSystem>();
            sounds = shower.GetComponentsInChildren<AudioSource>();
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
        foreach (AudioSource sound in sounds)
        {
            sound.Play();

        }
    }
}
