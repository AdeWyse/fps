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
    [SerializeField]
    private Gun equippedGun;
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
            equippedGun.shootRayPlayer();
        }

    }
}
