using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

	public Transform firePoint;
	[SerializeField]private GameObject bulletPrefab;

	public float fireRate = 0.1f;
	public float bulletSpeed = 20f;

	private bool isShooting = false;
	private float nextFireTime = 0f;

	[Header("Recoil Config")]

	public float recoilDistance = 0.1f;
	public float recoilSpeed = 0.1f;
	private Vector3 initialPosition;


	private void Start()
	{
		initialPosition = transform.localPosition;
	}
	void Update () 
	{

		if (UserInput.Instance.controls.Attack.Attack.WasPressedThisFrame()) 
		{			
			isShooting = true;
		}
		if (UserInput.Instance.controls.Attack.Attack.WasReleasedThisFrame()) 
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
		StartCoroutine(Recoil());
		GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}

	IEnumerator Recoil()
	{
		Vector3 recoilPosition = initialPosition + Vector3.left * recoilDistance; // Recuar na direção esquerda
		float elapsedTime = 0;

		// Move a arma para a posição de recuo
		while (elapsedTime < recoilSpeed)
		{
			transform.localPosition = Vector3.Lerp(initialPosition, recoilPosition, elapsedTime / recoilSpeed);
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		// Certifique-se de que a arma está na posição de recuo
		transform.localPosition = recoilPosition;

		// Resetar o tempo
		elapsedTime = 0;

		// Move a arma de volta para a posição inicial
		while (elapsedTime < recoilSpeed)
		{
			transform.localPosition = Vector3.Lerp(recoilPosition, initialPosition, elapsedTime / recoilSpeed);
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		// Certifique-se de que a arma está na posição inicial
		transform.localPosition = initialPosition;
	}

}
