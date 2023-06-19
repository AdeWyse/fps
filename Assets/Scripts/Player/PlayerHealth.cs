using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int healthPoints = 100;
    private int baseHealth = 100;
    public bool alive = true;
    public void TakeDamage(int damage)
    {
        healthPoints = healthPoints - damage;
    }

    public void HealDamage(int heal)
    {
        int temp = healthPoints + heal;
        if (temp > baseHealth)
        {
            healthPoints = baseHealth;
        }else
        {
            healthPoints = temp;
        }
    }

    public void Die()
    {
        if(healthPoints <= 0)
        {
            alive = false;
        }
        //call end game
    }

    public void Update()
    {
        Die();
    }
}
