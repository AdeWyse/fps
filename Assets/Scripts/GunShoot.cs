using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public float range = 1000;
    private LineRenderer lineRenderer;
    public bool playerOnly = false;

    public int ammo = 15;
    public int maxAmmo = 15;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetVertexCount(2);
    }

    public void Shoot(RaycastHit hit)
    {
       lineRenderer.SetPosition(0, transform.position);
    }
}

