using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    RaycastHit hit;
    float range = 1000.0f;

    public GameObject shotPrefab;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shootRayPlayer()
    {
        
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
 
        if(Physics.Raycast(ray, out hit, range))
        {
            GameObject laser =  GameObject.Instantiate(shotPrefab, transform.position, transform.rotation);
            laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            GameObject.Destroy(laser, 2f);
        }
    }

    public void shootRayNpc()
    {
        GameObject player = GameObject.Find("Player");
        if (gameManager.playerHealth > 0)
        {
            Ray ray = new Ray(player.transform.position, gameObject.transform.forward);
            if (Physics.Raycast(ray, out hit, range))
            {
                GameObject laser = GameObject.Instantiate(shotPrefab, transform.position, transform.rotation);
                laser.GetComponent<ShotBehavior>().setTarget(hit.point);
                GameObject.Destroy(laser, 2f);
            }
        }
       
    }
}
