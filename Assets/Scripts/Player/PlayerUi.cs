using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUi : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI prompText;
    [SerializeField]
    private TextMeshProUGUI enemiesCountText;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        enemiesCountText.text = gameManager.npcCount + "/" + gameManager.npcCountInitial ;
    }

    public void UpdateText(string promptMessage)
    {
        prompText.text = promptMessage;
    }
}
