using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.PackageManager;

public class ShotBehavior : MonoBehaviour {

	private Vector3 target;
	public float speed = 3.0f;
	public GameObject collisionExplosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position += transform.forward * Time.deltaTime * 1000f;
		float step = speed * Time.deltaTime;

		if(target != null )
		{
			if(transform.position == target)
			{
				explode();
				return;
			}
			transform.position = Vector3.MoveTowards(transform.position, target, step);
		}

	
	}

	public void setTarget(Vector3 targetHit)
	{
		target = targetHit;
	}

	public void explode()
	{
		if(collisionExplosion != null)
		{
            GameObject explosion = (GameObject)Instantiate(collisionExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 1f);
        }
		
	}

    private void OnCollisionEnter(Collision collision)
    {
		NpcMove npcShot = null;
		PlayerHealth playerShot = null;
        if (collision.collider.gameObject.tag == "Npc" || collision.collider.gameObject.tag == "NpcHead")
        {
            int points = 10;
            if (collision.collider.gameObject.tag == "Npc")
            {
                npcShot = collision.collider.GetComponent<NpcMove>();
            }
            if (collision.collider.gameObject.tag == "NpcHead")
            {
                npcShot = collision.collider.GetComponentInParent<NpcMove>();
                points = 51;
            }
            npcShot.TakeDamage(points);
        }
		
        if (collision.collider.gameObject.tag == "Player" )
        {
			
            int points = 5;
			playerShot = collision.collider.GetComponent<PlayerHealth>();
			playerShot.TakeDamage(points);

        }
    }
}
