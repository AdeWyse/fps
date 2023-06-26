using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    GameManager gameManager;
    public int healthPoints = 100;
    private int baseHealth;
    public bool alive = true;

    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        baseHealth = gameManager.baseHealth;
        healthPoints = baseHealth;
    }
    public void TakeDamage(int damage)
    {
        healthPoints = healthPoints - damage;
        gameManager.playerHealth = healthPoints;
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
        gameManager.playerHealth = healthPoints;
    }

    public void Die()
    {
       
        if (healthPoints <= 0)
        {
            alive = false;
            gameManager.running = 2;
        }

    }

    public void Update()
    {
        Die();
    }
}
