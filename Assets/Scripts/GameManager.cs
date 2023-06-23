using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int running = 0;
    private GameObject[] npcList;
    public int npcCount;
    public int npcCountInitial;
    

    // Start is called before the first frame update
    void Start()
    {
        npcList = GameObject.FindGameObjectsWithTag("Npc");
        npcCountInitial = npcList.Length;
        npcCount = npcCountInitial;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(npcCount < 0)
        {
            npcCount = 0;
        }
    }
}
