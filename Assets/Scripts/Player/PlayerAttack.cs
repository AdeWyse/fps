using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    private Camera cam;
    private float distance = 10f;
    private LayerMask mask;
    private InputManager inputManager;
    private Animator animator;
    private NpcMove npcShot;
    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<PlayerLook>().cam;
        inputManager = gameObject.GetComponent<InputManager>();
        animator = gameObject.GetComponentsInChildren<Animator>()[0];
        mask = LayerMask.GetMask("Npc");
    }

    // Update is called once per frame
    void Update()
    {
        ShotProcess();
    }

    public void ShotProcess()
    {
        if (inputManager.onFoot.Shoot.triggered)
        {
            animator.SetTrigger("Shot");
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, distance, mask))
            {
                if (hitInfo.collider.gameObject.tag == "Npc" || hitInfo.collider.gameObject.tag == "NpcHead")
                {
                    int points = 10;
                    if(hitInfo.collider.gameObject.tag == "Npc")
                    {
                        npcShot = hitInfo.collider.GetComponent<NpcMove>();
                    }
                    if (hitInfo.collider.gameObject.tag == "NpcHead")
                    {
                        npcShot = hitInfo.collider.GetComponentInParent<NpcMove>();
                        points = 51;
                    }
                        npcShot.TakeDamage(points);
                }
            }
        }

    }
}
