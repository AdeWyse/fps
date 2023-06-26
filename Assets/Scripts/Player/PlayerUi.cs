using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI prompText;
    [SerializeField]
    private TextMeshProUGUI enemiesCountText;
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private Image healthFill;
    [SerializeField]
    private TextMeshProUGUI healthText;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject winPanel;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        enemiesCountText.text = gameManager.npcCount + "/" + gameManager.npcCountInitial;
        UpdateHealth();

        if(gameManager.playerHealth <= 0)
        {
            gameOverPanel.SetActive(true);
        }

        if (gameManager.npcCount <= 0)
        {
            winPanel.SetActive(true);
        }
    }

    public void UpdateText(string promptMessage)
    {
        prompText.text = promptMessage;
    }

    public void UpdateHealth()
    {
        int health = gameManager.playerHealth;
        healthSlider.value = health;
        healthText.text = health.ToString();
        if(healthSlider.value > (gameManager.baseHealth * 0.75f)){
            healthFill.color = Color.cyan;
            healthText.color = Color.cyan;
        }
        if (healthSlider.value < (gameManager.baseHealth * 0.75f))
        {
            healthFill.color = Color.green;
            healthText.color = Color.green;
        }
        if (healthSlider.value < (gameManager.baseHealth * 0.5f))
        {
            healthFill.color = Color.yellow;
            healthText.color = Color.yellow;
        }
        if (healthSlider.value < (gameManager.baseHealth * 0.25f))
        {
            healthFill.color = Color.red;
            healthText.color = Color.red;
        }
    }
}
