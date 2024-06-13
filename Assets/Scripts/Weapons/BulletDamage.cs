using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public enum BulletType 
	{
		Normal,
		Physics
	}
public class BulletDamage : MonoBehaviour {
	[Header("Layer")]
	[SerializeField] private LayerMask whatDestroysBullet;

	[Space]
	[SerializeField] private float timeToDestroyBullet = 5;

	[Header("Normal bullet stats")]
	[SerializeField] private float normalBulletSpeed = 20f;
	[SerializeField] private int normalBulletDamage = 1;

	[Header("Physics bullet stats")]
	[SerializeField] private float physicBulletSpeed = 10f;
	[SerializeField] private int physicBulletDamage = 2;

	[Header("VFX")]
	[SerializeField] private GameObject enemyPrefabVFX;
	[SerializeField] private GameObject groundPrefabVFX;
	

	private Rigidbody2D rb;


	public BulletType bulletType;

	void Start () {
		rb = GetComponent<Rigidbody2D>();

		Destroy(gameObject, timeToDestroyBullet);


		InitializedBulletStats();
		
	}
	private void FixedUpdate()
	{
		if (bulletType == BulletType.Physics)
		{
			transform.right = rb.velocity;
		}
	}

	private void InitializedBulletStats()
	{
		if (bulletType == BulletType.Normal)
		{
			SetNormalVelocity();
		}
		else if (bulletType == BulletType.Physics) 
		{
			SetPhysicsVelocity();
		}
	}

	private void SetNormalVelocity() 
	{
		rb.velocity = transform.right * normalBulletSpeed;
	}
	private void SetPhysicsVelocity()
	{
		rb.velocity = transform.right * physicBulletSpeed;
		rb.gravityScale = 1f;
	}
	void OnTriggerEnter2D(Collider2D col)
    {
		if((whatDestroysBullet.value & (1<< col.gameObject.layer)) > 0) 
		{
			if (col.gameObject.layer == 11)
			{
				EnemyHealth enemyHealth = col.GetComponent<EnemyHealth>();

				if (enemyHealth != null)
				{
					enemyHealth.Damage(normalBulletDamage);
				}

				//VFX
				GameObject enemVFX = Instantiate(enemyPrefabVFX, transform.position, Quaternion.identity);
			}
			else 
			{
				GameObject groundVFX = Instantiate(groundPrefabVFX, transform.position, Quaternion.identity);
			}

			Destroy(gameObject);
		}
		
    }

	

}
