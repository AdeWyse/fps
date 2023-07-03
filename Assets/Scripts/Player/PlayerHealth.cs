using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    GameManager gameManager;
    public int healthPoints = 100;
    private int baseHealth;
    public bool alive = true;
    private GameObject damagePanel;
    public void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        damagePanel = GameObject.Find("Damage");
        damagePanel.SetActive(false);
        baseHealth = gameManager.baseHealth;
        healthPoints = baseHealth;
    }
    public void TakeDamage(int damage)
    {
        damagePanel.SetActive(true);
        healthPoints = healthPoints - damage;
        gameManager.playerHealth = healthPoints;
        Invoke("HideDamage", 1.5f);
    }

    private void HideDamage()
    {
        damagePanel.SetActive(false);
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
        gameObject.GetComponent<AudioSource>().Play();
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
