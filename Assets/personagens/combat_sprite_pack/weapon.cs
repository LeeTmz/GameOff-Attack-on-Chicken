using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;

	public float fireRate = 0.1f;
	public float bulletSpeed = 20f;

	private bool isShooting = false;
	private float nextFireTime = 0f;
	void Update () {

		if (Input.GetMouseButtonDown(0))
		{
			isShooting = true;
		}

		if (Input.GetMouseButtonUp(0))
		{
			isShooting = false;
		}

		if (isShooting && Time.time >= nextFireTime)
		{
			Shoot();
			nextFireTime = Time.time + fireRate;
		}
	}
	void Shoot()
	{
		GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);		
	}

}
